using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyHttpServer
{
    public class Client
    {
        public Client(TcpClient client)
        {
            StringBuilder requestSB = new StringBuilder();
            // Буфер для хранения принятых от клиента данных
            byte[] buffer = new byte[1024];
            // Переменная для хранения количества байт, принятых от клиента
            int count;
            // Читаем из потока клиента до тех пор, пока от него поступают данные
            while ((count = client.GetStream().Read(buffer, 0, buffer.Length)) > 0)
            {
                // Преобразуем эти данные в строку и добавим ее к переменной Request
                requestSB.Append(Encoding.ASCII.GetString(buffer, 0, count));
                // Запрос должен обрываться последовательностью \r\n\r\n
                // Либо обрываем прием данных сами, если длина строки Request превышает 4 килобайта
                // Нам не нужно получать данные из POST-запроса (и т. п.), а обычный запрос
                // по идее не должен быть больше 4 килобайт
                if (requestSB.ToString().IndexOf("\r\n\r\n") >= 0 || requestSB.Length > 4096)
                    break;
            }
            string request = requestSB.ToString();
            // Парсим строку запроса с использованием регулярных выражений
            // При этом отсекаем все переменные GET-запроса
            Match reqMatch = Regex.Match(request, @"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");
            // Если запрос не удался
            if (reqMatch == Match.Empty)
            {
                // Передаем клиенту ошибку 400 - неверный запрос
                SendError(client, 400);
                return;
            }
            // Получаем строку запроса
            string requestUri = reqMatch.Groups[1].Value;
            // Приводим ее к изначальному виду, преобразуя экранированные символы
            // Например, "%20" -> " "
            requestUri = Uri.UnescapeDataString(requestUri);
            // Если в строке содержится двоеточие, передадим ошибку 400
            // Это нужно для защиты от URL типа http://example.com/../../file.txt
            if (requestUri.IndexOf("..") >= 0)
            {
                SendError(client, 400);
                return;
            }
            // Если строка запроса оканчивается на "/", то добавим к ней index.html
            if (requestUri.EndsWith("/"))
                requestUri += "index.html";
            
            string filePath = "www/" + requestUri;

            // Если в папке www не существует данного файла, посылаем ошибку 404
            if (!File.Exists(filePath))
            {
                SendError(client, 404);
                return;
            }

            // Получаем расширение файла из строки запроса
            string extension = requestUri.Substring(requestUri.LastIndexOf('.'));

            // Тип содержимого
            string contentType = "";

            // Пытаемся определить тип содержимого по расширению файла
            switch (extension)
            {
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".css":
                    contentType = "text/stylesheet";
                    break;
                case ".js":
                    contentType = "text/javascript";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".jpeg":
                case ".png":
                case ".gif":
                    contentType = "image/" + extension.Substring(1);
                    break;
                default:
                    if (extension.Length > 1)
                        contentType = "application/" + extension.Substring(1);
                    else
                        contentType = "application/unknown";
                    break;
            }

            // Открываем файл, страхуясь на случай ошибки
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception)
            {
                // Если случилась ошибка, посылаем клиенту ошибку 500
                SendError(client, 500);
                return;
            }

            // Посылаем заголовки
            string headers = $"HTTP/1.1 200 OK\nContent-Type: {contentType}\nContent-Length: {fileStream.Length}\n\n";
            byte[] headersBuffer = Encoding.ASCII.GetBytes(headers);
            client.GetStream().Write(headersBuffer, 0, headersBuffer.Length);

            // Пока не достигнут конец файла
            while (fileStream.Position < fileStream.Length)
            {
                // Читаем данные из файла
                count = fileStream.Read(buffer, 0, buffer.Length);
                // И передаем их клиенту
                client.GetStream().Write(buffer, 0, count);
            }

            // Закроем файл и соединение
            fileStream.Close();
            client.Close();
        }

        private void SendError(TcpClient client, int code)
        {
            // Получаем строку вида "200 OK"
            // HttpStatusCode хранит в себе все статус-коды HTTP/1.1
            string codeStr = code.ToString() + " " + ((HttpStatusCode)code).ToString();
            // Код простой HTML-странички
            string html = $"<html><body><h1>{codeStr}</h1></body></html>";
            // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
            string str = $"HTTP/1.1 {codeStr} \nContent-type: text/html\nContent-Length:{html.Length}\n\n{html}";
            // Приведем строку к виду массива байт
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            // Отправим его клиенту
            client.GetStream().Write(buffer, 0, buffer.Length);
            // Закроем соединение
            client.Close();
        }
    }
}

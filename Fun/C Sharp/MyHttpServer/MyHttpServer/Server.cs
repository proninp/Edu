using System.Net;
using System.Net.Sockets;

namespace MyHttpServer
{
    public class Server
    {
        TcpListener Listener;
        public Server(int port)
        {
            Listener = new TcpListener(IPAddress.Any, port);
            Listener.Start();

            while(true)
            {
                var client  = new Client(Listener.AcceptTcpClient());
                // Принимаем новых клиентов
                // После того, как клиент был принят, он передается в новый поток (ClientThread) с использованием пула потоков
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), client);
            }
        }
        ~Server() => Listener?.Stop();

        static void Main(string[] args)
        {

            new Server(7408);
        }
        static void ClientThread(Object StateInfo)
        {
            // Максимальное количество потоков - по 4 на каждый процессор
            int maxThreadCount = Environment.ProcessorCount * 4;
            // Установим максимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(maxThreadCount, maxThreadCount);
            // Установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(2, 2);
            new Client((TcpClient)StateInfo);
        }
    }
}
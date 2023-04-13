using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal interface ILinkedList
    {
        int GetCount(); // возвращает количество элементовв списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляетновый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанныйэлемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }
}

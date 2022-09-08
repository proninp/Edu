﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    public interface ILinkedList
    {
        int GetCount();
        void AddNode(int value);
        void AddNodeAfter(Node node, int value);
        void RemoveNode(int index);
        void RemoveNode(Node node);
        Node FindNode(int searchValue);
    }
}

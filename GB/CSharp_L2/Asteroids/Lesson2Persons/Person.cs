﻿using System;

namespace Lesson2Persons
{
    abstract class Person: IComparable
    {
        protected string Name { get; set; }
        protected string Surname { get; set; }
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        protected abstract double GetAvgSalary();
        public abstract void DisplayInfo();

        public virtual int CompareTo(object obj) => ((GetAvgSalary()) > ((Person)obj).GetAvgSalary()) ? 1 : 
            ((GetAvgSalary() < ((Person)obj).GetAvgSalary()) ? -1 : 0);
    }
}

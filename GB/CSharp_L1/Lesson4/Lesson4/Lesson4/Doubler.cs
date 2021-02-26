using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*
     * Исполнитель:
     * Пронин Павел
     * 
     * Класс "Удвоитель"
     * Содерджит поля и методы для игры "Удвоитель"
     */
    class Doubler
    {
        int current;
        int finish;

        #region Свойства
        public int Current
        {
            get { return current; }
        }
        public int Finish
        {
            get { return finish; }
        }
        #endregion

        #region Конструктор
        public Doubler(int min, int max, Random r)
        {
            if (min > max)
                CommonMethods.Swap(ref min, ref max);
            finish = r.Next(min, max);
            current = 1;
        }
        #endregion

        #region Методы
        public void Increase()
        {
            current++;
        }
        public void MultiTwice()
        {
            current *= 2;
        }
        public void Reset()
        {
            current = 1;
        }
        #endregion
    }
}

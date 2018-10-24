using System;

namespace Asteroids
{
    /*
     * *Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками
     * (например, отрицательные размеры, слишком большая скорость или позиция).
     */
    class GameObjectException : ArgumentException
    {
        public GameObjectException(string msg) : base(msg) { }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject: ICollision
    {
        /// <summary>
        /// Делегат для оброботчика событий гибели корабля
        /// </summary>
        public delegate void Message();
        protected static Random rand = new Random();
        /// <summary>
        /// Лимит выхода объекта за пределы экрана
        /// </summary>
        static readonly int beyoundLim = 101;
        /// <summary>
        /// Позиция
        /// </summary>
        public Point Pos;
        /// <summary>
        /// Шаг изменения позиции
        /// </summary>
        protected Point Dir;
        /// <summary>
        /// Размер
        /// </summary>
        protected Size Size;
        /// <summary>
        /// Кол-во жизни объекта
        /// </summary>
        protected int health;
        /// <summary>
        /// Уровень здоровья
        /// </summary>
        public virtual int Health
        {
            get { return health; }
            set { health = value; }
        }
        /// <summary>
        /// Размер прямоугольной области объекта
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изенения позиции</param>
        protected BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
        }
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="size">Размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size): this(pos, dir) => Size = size;
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Уровень здоровья</param>
        protected BaseObject(Point pos, Point dir, int health): this(pos, dir) => Health = health;
        /// <summary>
        /// Конструктор, принимающий позицию, смещение, размер и уровень здоровья
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Смещение</param>
        /// <param name="health">Уровень здоровья</param>
        /// <param name="size">Размер</param>
        protected BaseObject(Point pos, Point dir, int health, Size size) : this(pos, dir, health) => Size = size;
        /// <summary>
        /// Метод для отрисовки
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Метод для обновления позиции объекта
        /// </summary>
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < -beyoundLim) Pos.X = Game.Width + beyoundLim - 1;
            if (Pos.X > (Game.Width + beyoundLim)) Pos.X = -beyoundLim + 1;
            if (Pos.Y > Game.Height + beyoundLim) Pos.Y = 0;
            
            if (Pos.Y < -beyoundLim) Pos.Y = Game.Height;
        }
        /// <summary>
        /// Пересечение объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Collision(ICollision obj) => ((BaseObject)obj).Rect.IntersectsWith(Rect);
        /// <summary>
        /// Убираем экземпляр из списка и обнуляем ссылку
        /// </summary>
        /// <param name="list"></param>
        /// <param name="i"></param>
        public virtual void Del<T>(List<T> list, int i)
        {
            list[i] = default(T);
            if (i >= 0 && i < list.Count) list.RemoveAt(i);
        }
    }
}
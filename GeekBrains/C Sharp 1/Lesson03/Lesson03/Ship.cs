using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    
    public class Ship
    {
        public int DeckCount { get; set; }
        public Point[] Points { get; set; }
        private Random random;
        private enum Directions
        {
            Left,
            Right,
            Top,
            Bottom
        };
        private Directions[] dirs = { Directions.Left, Directions.Right, Directions.Top, Directions.Bottom }; // Направления движения при создании новой палубы

        public Ship() { }
        public Ship(int deckCount, int[,] battleField)
        {
            DeckCount = deckCount;
            random = new Random();
            CreateShipRandom(battleField);
        }
        private void CreateShipRandom(int[,] battleField)
        {
            // Собираем точки поля, являющиеся соседними с точками, в которых установлены единицы, нужно для последующей проверки корректности установки новых точек
             CollectAllOccupiedPoints(battleField, out List<Point> neighboringPointsOnBF);

            while (true)
            {    
                if (TrySelectShipCoordinates(battleField, neighboringPointsOnBF))
                {
                    foreach (Point p in Points)
                        battleField[p.Y, p.X] = 1;
                    break;
                }
            }
        }
        private bool TrySelectShipCoordinates(int[,] battleField, List<Point> neighboringPointsOnBF)
        {
            int randomPointX = random.Next(0, battleField.GetLength(0));
            int randomPointY = random.Next(0, battleField.GetLength(0));

            Points = new Point[DeckCount];

            if (!CheckValidPoint(randomPointX, randomPointY, battleField, neighboringPointsOnBF))
                return false;
            
            Points[0] = new Point(randomPointX, randomPointY);
            if (DeckCount == 1)
                return true;

            ShiftDirsArray(); // Сдвигаем массив направлений вправо на N элементов, где 1 >= N <= 5
            for (int i = 0; i < dirs.Length; i++)
                if (TrySelectShipCoordinatesWithDirection(battleField, dirs[i], neighboringPointsOnBF))
                    return true;

            return false;
        }
        private bool TrySelectShipCoordinatesWithDirection(int[,] battleField, Directions direction, List<Point> neighboringPointsOnBF)
        {
            for (int i = 1/*В момент выполнения функции у нас уже есть первая точка*/; i < Points.Length; i++)
            {
                Point point = GetNewPointByDirection(direction, Points[i - 1]);
                if (!CheckValidPoint(point.X, point.Y, battleField, neighboringPointsOnBF))
                    return false;
                Points[i] = point;
            }
            return true;
        }
       
        private bool CheckValidPoint(int x, int y, int[,] battleField, List<Point> neighboringPointsOnBF)
        {
            if (x >= battleField.GetLength(1) || y >= battleField.GetLength(0) || x < 0 || y < 0) // Точка за пределами поля
                return false;

            Point newPoint = new Point(x, y);
            if (Points.Length > 0)
                if (Points.Contains(newPoint)) // Точка содержится в ранее добавленном массиве новых точек
                    return false;

            if (neighboringPointsOnBF.Contains(newPoint)) // Точка содержится в точках, соседних с установленными на поле
                return false;

            return true;
        }
            
        private void CollectAllOccupiedPoints(int[,] battleField, out List<Point> neighboringPointsOnBF)
        {
            neighboringPointsOnBF = new List<Point>();
            for (int i = 0; i < battleField.GetLength(0); i++)
                for (int j = 0; j < battleField.GetLength(1); j++)
                    if (battleField[i, j] == 1)
                        GetNeighboringPoints(j, i, neighboringPointsOnBF); // Собираем точку и все точки вокруг неё
        }
        private void GetNeighboringPoints(int x, int y, List<Point> neighboringPointsOnBF)
        {
            int minCoord = -1;
            int maxCoord = 1;

            for (int yStep = minCoord; yStep <= maxCoord; yStep++)
                for (int xStep = minCoord; xStep <= maxCoord; xStep++)
                {
                    Point p = new Point(x + xStep, y + yStep);
                    if (!neighboringPointsOnBF.Contains(p))
                        neighboringPointsOnBF.Add(p);
                }
        }

        private Point GetNewPointByDirection(Directions dir, Point currentPoint)
        {
            switch (dir)
            {
                case Directions.Left:
                    return new Point(currentPoint.X + 1, currentPoint.Y);
                case Directions.Right:
                    return new Point(currentPoint.X - 1, currentPoint.Y);
                case Directions.Top:
                    return new Point(currentPoint.X, currentPoint.Y - 1);
                default: // Bottom
                    return new Point(currentPoint.X + 1, currentPoint.Y + 1);
            }
        }
        /// <summary>
        /// Функция для сдвига массива направлений на случайное число элементов, используется для нелинейного создания кораблей - горизонтальный/вертикальный
        /// </summary>
        private void ShiftDirsArray()
        {
            int shifts = random.Next(1, 6);
            if (shifts == dirs.Length)
                return;
            for (int i = 0; i < shifts; i++)
            {
                for (int j = 0; j < dirs.Length-1; j++)
                {
                    Directions dir = dirs[j];
                    dirs[j] = dirs[j + 1];
                    dirs[j + 1] = dir;
                }
            }
        }
    }
    

}

using System.Drawing;

namespace Asteroids
{
    interface ICollision
    {
        Rectangle Rect { get; set; }
        bool Collision(ICollision obj);
    }
}

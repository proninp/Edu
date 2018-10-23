using System.Drawing;

namespace Asteroids
{
    interface ICollision
    {
        Rectangle Rect { get; set; }
        bool IsDestroy { get; set; }
        bool Collision(ICollision obj);
    }
}

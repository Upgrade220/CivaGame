using System.Drawing;

namespace CivaGame
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        void Move(Direction direction);
    }
}

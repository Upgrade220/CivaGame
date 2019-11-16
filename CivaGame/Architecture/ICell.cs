using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public interface ICell
    {
        void Interact(int x, int y);
        string GetImageFileName();

    }
}

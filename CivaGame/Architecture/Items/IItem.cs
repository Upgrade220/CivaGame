using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public interface IItem
    {
        string GetImageFileName();
        int MaxStack();
    }
}

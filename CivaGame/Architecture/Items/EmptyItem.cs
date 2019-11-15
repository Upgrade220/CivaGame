using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    class EmptyItem : IItem
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}

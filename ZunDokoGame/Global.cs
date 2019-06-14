using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZunDokoGame
{
    static class Global
    {
        public static readonly int sizeX;
        public static readonly int sizeY;
         static Global()
        {
            int  colorBitDepth;
            DX.GetScreenState(out sizeX, out sizeY, out colorBitDepth);
        }
    }
}

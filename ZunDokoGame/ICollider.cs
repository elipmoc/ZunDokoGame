using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZunDokoGame
{

    //当たり判定を持つオブジェクトの性質のインターフェイス
    interface ICollider
    {
        int X { get; }
        int Y { get; }
        int SizeX { get; }
        int SizeY { get; }
    }
}

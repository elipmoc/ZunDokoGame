using DxLibDLL;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ZunDokoGame
{
    class Player : ICollider
    {
        const int PlayerSize = 48;
        const int speed = 7;

        int x = (Global.sizeX - PlayerSize) / 2;
        int y = Global.sizeY - PlayerSize;

        readonly int handle;

        public int X => x + PlayerSize / 2;

        public int Y => y + PlayerSize / 2;

        public int SizeX => PlayerSize-8;

        public int SizeY => PlayerSize-8;

        public Player()
        {
            handle = DX.LoadGraph("resource/img/BB.jpg");
        }

        public void Update()
        {
            if (DX.CheckHitKey(DX.KEY_INPUT_LEFT) == DX.TRUE)
                x -= speed;
            if (DX.CheckHitKey(DX.KEY_INPUT_RIGHT) == DX.TRUE)
                x += speed;
            if (x > Global.sizeX - PlayerSize) x = Global.sizeX - PlayerSize;
            if (x < 0) x = 0;
            DX.DrawGraph(x, y, handle, DX.FALSE);

        }
    }
}

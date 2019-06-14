using DxLibDLL;

namespace ZunDokoGame
{
    class TimeText
    {
        public int Time { set; private get; } = 0;
        public void Draw()
        {
            DX.DrawString(0, 0, "Time:" + Time, DX.GetColor(255, 255, 255));
        }
    }
}

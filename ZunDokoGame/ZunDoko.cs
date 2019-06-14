using DxLibDLL;

namespace ZunDokoGame
{
    class ZunDoko : ICollider
    {
        string word;
        float y = 0;
        readonly int x;
        readonly float speed;
        readonly uint color;
        readonly int handle;

        public int X => x + SizeX / 2;

        public int Y => (int)(y + SizeY / 2);

        public int SizeX => Size;

        public int SizeY => DX.GetDrawStringWidthToHandle(word, 2, handle);

        public int Size => DX.GetDrawStringWidthToHandle(word, word.Length * 2, handle);

        public ZunDoko(string word, int handle, uint color, float speed, int x)
        {
            this.word = word;
            this.x = x;
            this.color = color;
            this.speed = speed;
            this.handle = handle;

        }
        public void Update()
        {
            DX.DrawStringToHandle(x, (int)y, word, color, handle);
            y += speed;
        }
    }
}

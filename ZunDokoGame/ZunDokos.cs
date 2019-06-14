using DxLibDLL;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ZunDokoGame
{
    class ZunDokos : IEnumerable<ICollider>
    {
        const int interval = 20;
        Random rand = new Random();
        float count = 0;

        string[] zunDokoArray = new string[] { "ズン", "ドコ" };
        int index = 0;
        string[] zunDokoKiyosi = new string[] { "ズン", "ズン", "ズン", "ズン", "ドコ", "キ・ヨ・シ！！" };

        int zunDokoFontHandle;
        int kiyosiFontHandle;

        List<ZunDoko> zunDokoList = new List<ZunDoko>();

        public ZunDokos()
        {
            kiyosiFontHandle = DX.CreateFontToHandle(null, 43, -1, -1);
            zunDokoFontHandle = DX.CreateFontToHandle(null, -1, -1, -1);
        }


        public IEnumerator<ICollider> GetEnumerator()
        {
            foreach (var item in zunDokoList)
            {
                yield return item;
            };
        }

        public void Update(float rate)
        {
            if (count <= 0)
            {
                var word = zunDokoArray[rand.Next(2)];
                if (word == zunDokoKiyosi[index]) index++;
                else index = 0;
                if (index == 5)
                {
                    index = 0;
                    zunDokoList.Add(new ZunDoko(zunDokoKiyosi[5], kiyosiFontHandle, DX.GetColor(0, 255, 0), 10 * rate, (int)(rand.NextDouble() * (Global.sizeX - 80))));
                }
                else
                    zunDokoList.Add(new ZunDoko(word, zunDokoFontHandle, DX.GetColor(255, 0, 0), 6 * rate, (int)(rand.NextDouble() * (Global.sizeX - 30))));

                count = interval;

            }
            else count-=rate;
            zunDokoList.ForEach(x => x.Update());
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}

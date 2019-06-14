using System;
using DxLibDLL;

namespace ZunDokoGame
{
    class ResultScene : IScene
    {
        int time;
        int handle;
        IScenePusher scenePusher;

        public ResultScene(int time,IScenePusher scenePusher)
        {
            this.time = time;
            this.scenePusher = scenePusher;
            handle= DX.CreateFontToHandle(null, 30, -1, -1);
        }
        public void Update()
        {
            DX.DrawStringToHandle(Global.sizeX / 2-300, Global.sizeY / 2,$"あなたは{time}フレーム生き残りました", DX.GetColor(255, 255, 255), handle);
            if (DX.CheckHitKey(DX.KEY_INPUT_RETURN) == DX.TRUE)
                scenePusher.PushScene(null);
        }
    }
}

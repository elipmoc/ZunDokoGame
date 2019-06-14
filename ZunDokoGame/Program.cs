using DxLibDLL;
using System;
using System.Collections.Generic;

namespace ZunDokoGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DX.ChangeWindowMode(DX.TRUE);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);

            var sceneManager = new SceneManager();
            sceneManager.PushScene(new GameScene(sceneManager));

            while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
            {
                sceneManager.Update();
                if (sceneManager.IsSceneEmpty()) break;
            }
            DX.DxLib_End();
        }

        
    }
}

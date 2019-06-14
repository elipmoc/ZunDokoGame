using DxLibDLL;
using System.Collections.Generic;

namespace ZunDokoGame
{
    class GameScene : IScene
    {
        Player player = new Player();
        ZunDokos zunDokos = new ZunDokos();
        TimeText timeText = new TimeText();
        float rate = 0.5f;
        int time = 0;
        int explosionHandle;
        int piHandle;
        IScenePusher scenePusher;

        public GameScene(IScenePusher scenePusher)
        {
            this.scenePusher = scenePusher;
            explosionHandle = DX.LoadSoundMem("resource/sound/explosion.mp3");
            piHandle = DX.LoadSoundMem("resource/sound/pi.mp3");
        }

        public void Update()
        {
            timeText.Time = time;
            timeText.Draw();
            time++;
            if (time % 1000 == 0)
                DX.PlaySoundMem(piHandle, DX.DX_PLAYTYPE_BACK);
            player.Update();
            zunDokos.Update(rate);
            if (CalcCollision(player, zunDokos))
            {
                DX.PlaySoundMem(explosionHandle, DX.DX_PLAYTYPE_BACK);
                scenePusher.PushScene(new ResultScene(time, scenePusher));
            }
            rate += 0.0001f;
        }

        bool CalcCollision(ICollider player, IEnumerable<ICollider> zunDokoz)
        {

            var topPY = player.Y - player.SizeY / 2;
            var bottomPY = player.Y + player.SizeY / 2;

            var leftPX = player.X - player.SizeX / 2;
            var rightPX = player.X + player.SizeX / 2;
            //DX.DrawBox(leftPX, topPY, rightPX, bottomPY, DX.GetColor(0, 0, 200), DX.FALSE);

            foreach (var item in zunDokoz)
            {
                var topZY = item.Y - item.SizeY / 2;
                var bottomZY = item.Y + item.SizeY / 2;

                var leftZX = item.X - item.SizeX / 2;
                var rightZX = item.X + item.SizeX / 2;
                //DX.DrawBox(leftZX, topZY, rightZX, bottomZY, DX.GetColor(0, 0, 200), DX.FALSE);

                if (
                    (topPY >= topZY && topPY <= bottomZY || bottomPY >= topZY && bottomPY <= bottomZY) &&
                    (leftPX >= leftZX && leftPX <= rightZX || rightPX >= leftZX && rightPX <= rightZX) ||
                    (topZY >= topPY && topZY <= bottomPY || bottomZY >= topPY && bottomZY <= bottomPY) &&
                    (leftZX >= leftPX && leftZX <= rightPX || rightZX >= leftPX && rightZX <= rightPX)
                )
                    return true;
            }
            return false;
        }
    }
}

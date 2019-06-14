
namespace ZunDokoGame
{
    class SceneManager : IScenePusher
    {
        IScene currentScene;

        public bool IsSceneEmpty() => currentScene == null;
        public void Update()
        {
            if (currentScene != null)
                currentScene.Update();
        }
        public void PushScene(IScene scene)
         => currentScene = scene;
    }
}

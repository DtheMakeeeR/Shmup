using Eflatun.SceneReference;
using MEC;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public static class Loader
    {
        static SceneReference targetScene;
        static SceneReference loadingScene = new(SceneGuidToPathMapProvider.ScenePathToGuidMap["Assets/Scenes/Loading.unity"]);
        public static void Load(SceneReference scene)
        {
            targetScene = scene;
            SceneManager.LoadScene(loadingScene.Name);
            Timing.RunCoroutine(_LoadTargetScene());
        }

        private static IEnumerator<float> _LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetScene.Name);
        }
    }
}

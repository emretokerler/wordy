using UnityEngine;
using Wordy.Services.Scenes;

namespace Wordy.Services
{
    public static class SLBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            ServiceLocator.Initialize();
            ServiceLocator.Current.Register(new SceneService());
        }
    }
}

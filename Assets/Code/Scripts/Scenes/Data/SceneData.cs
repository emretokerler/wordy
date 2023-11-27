using UnityEngine;

namespace Wordy.Services.Scenes.Data
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObject/SceneData")]
    public class SceneData : ScriptableObject
    {
        public GameObject SceneContent;
    }
}

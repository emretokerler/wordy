using UnityEngine;
using Wordy.Grids;
using Wordy.Resources;

namespace Wordy.Words.Data
{
    [CreateAssetMenu(fileName = "WordsHelperData", menuName = "ScriptableObject/WordsHelperData")]
    public class WordsHelperData : ScriptableObject
    {
        public WordLoadMethod WordLoadMethod = WordLoadMethod.Local;
        public LocalLoadMethod LocalLoadMethod = LocalLoadMethod.Addressables;
        public string BaseURL = "";
        public string URL = "";
        public string FileName = "Words.json";
        public string FullFileSavePath => GetFullFileSavePath();
        public string FullURL => $"{BaseURL}/{FileName}";

        private string GetFullFileSavePath()
        {
            switch (LocalLoadMethod)
            {
                case LocalLoadMethod.Addressables: return $"{AddressablePaths.WORDS_DATA_ROOT}/{FileName}";
                case LocalLoadMethod.PersistentDataPath: return $"{Application.persistentDataPath}/{FileName}";
                case LocalLoadMethod.StreamingAssets: return $"{Application.streamingAssetsPath}/{FileName}";
                default: return string.Empty;
            }
        }
    }

    public enum WordLoadMethod
    {
        Local,
        Remote
    }

    public enum LocalLoadMethod
    {
        Addressables,
        PersistentDataPath,
        StreamingAssets,
        Resources
    }


}

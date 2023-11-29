using UnityEngine;
using Wordy.Grids;

namespace Wordy.Words.Data
{
    [CreateAssetMenu(fileName = "WordsHelperData", menuName = "ScriptableObject/WordsHelperData")]
    public class WordsHelperData : ScriptableObject
    {
        public WordLoadMethod WordLoadMethod = WordLoadMethod.Local;
        public string BaseURL = "";
        public string URL = "";
        public string FilePath = "words.json";
        public string FullFileSavePath => $"{Application.persistentDataPath}/{FilePath}";
        public string FullURL => $"{BaseURL}/{FilePath}";
    }

    public enum WordLoadMethod
    {
        Local,
        Remote
    }

    public enum LocalLoadMethod
    {
        Local,
        Remote
    }


}

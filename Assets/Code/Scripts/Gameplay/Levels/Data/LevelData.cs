using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wordy.Words;

namespace Wordy.Levels
{
    [System.Serializable]
    public class LevelData
    {
        public int GridWidth, GridHeight, WordCount, WordLength;
        [HideInInspector] public List<Word> Words;
    }
}
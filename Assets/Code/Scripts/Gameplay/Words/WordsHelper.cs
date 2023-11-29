using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Wordy.Grids;
using Wordy.Resources;
using Wordy.Words.Data;

namespace Wordy.Words
{
    public class WordsHelper : SingletonMonobehaviour<WordsHelper>
    {
        private WordsHelperData config;
        public List<Word> LoadedWords;
        public void Initialize() => AddressableHelper.Load<WordsHelperData>(AddressablePaths.DEFAULT_WORDSHELPER_DATA, wordsHelperData => Initialize(wordsHelperData));
        public void Initialize(WordsHelperData wordsHelperData)
        {
            config = wordsHelperData;
            LoadWords();
        }

        void LoadWords()
        {
            if (config.WordLoadMethod == WordLoadMethod.Local)
            {
                var contentStr = File.ReadAllText(config.FilePath);

                var wordsData = JsonUtility.FromJson<WordsData>(contentStr);
                for (int i = 0; i < wordsData.words.Length; i++)
                {
                    LoadedWords.Add(new Word(wordsData.words[i]));
                }
            }
        }

        public static List<Word> CreateWordsForCells(List<Cell> cells)
        {
            if (Instance.LoadedWords == null) Debug.LogError("Words not loaded yet");

            var words = new List<Word>();
            var wordsToUse = new List<Word>(Instance.LoadedWords);

            wordsToUse.ForEach(w =>
            {
                words.Add(new Word { Cells = cells });
            });

            return words;
        }

    }
}
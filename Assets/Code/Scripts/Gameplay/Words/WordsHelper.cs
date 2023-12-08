using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Wordy.Grids;
using Wordy.Resources;
using Wordy.Services;
using Wordy.Words.Data;

namespace Wordy.Words
{
    public class WordsHelper : BaseService
    {
        private WordsHelperData config;
        public List<Word> WordsLibrary;

        public override void Initialize()
        {
            AddressableHelper.Load<WordsHelperData>(AddressablePaths.DEFAULT_WORDSHELPER_DATA, (wordsHelperData) =>
            {
                config = wordsHelperData;
                LoadWords();
                IsInitialized = true;
            });
        }

        void LoadWords()
        {
            WordsLibrary = new();
            if (config.WordLoadMethod == WordLoadMethod.Local)
            {
                if (config.LocalLoadMethod == LocalLoadMethod.Addressables)
                {
                    var contentStr = File.ReadAllText(config.FullFileSavePath);

                    var wordsData = JsonUtility.FromJson<WordsData>(contentStr);
                    for (int i = 0; i < wordsData.Words.Length; i++)
                    {
                        WordsLibrary.Add(new Word(wordsData.Words[i]));
                    }
                }
            }
        }

        public List<Word> CreateWordsForCells(List<Cell> cells)
        {
            if (WordsLibrary == null) Debug.LogError("Words not loaded yet");

            var words = new List<Word>();
            var wordsToUse = new List<Word>(WordsLibrary);

            wordsToUse.ForEach(w =>
            {
                // words.Add(new Word { Cells = cells });
            });
            return words;
        }

        public List<Word> GetWords(int wordCount, int wordLength)
        {
            if (WordsLibrary == null) Debug.LogError("Words not loaded yet");

            var words = WordsLibrary.FindAll((w) => w.Length == wordLength);
            words.Sort((w1, w2) => 1 - Random.Range(0, 2) * 2);
           
            return  words.GetRange(0, wordCount);
        }
    }
}
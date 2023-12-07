using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wordy.Resources;
using Wordy.Services;
using Wordy.Utils;
using Wordy.Words;
using Random = UnityEngine.Random;

namespace Wordy.Grids
{
    public class GridHelper : BaseService
    {
        public override void Initialize()
        {
            IsInitialized = true;
        }

        public void SpawnDefaultGridView(Transform parent, Action<GridView> OnComplete)
        {
            AddressableHelper.Instantiate(AddressablePaths.DEFAULT_GRIDVIEW_PREFAB, parent, Vector3.zero, Quaternion.identity, OnComplete);
        }

        public Grid CreateEmptyGrid(int width, int height)
        {
            return new Grid(width, height);
        }

        public void FillWithWords(Grid grid, List<Word> words)
        {

            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];
                var randomTraverser = GetRandomTraverser(grid);

                try
                {
                    var availableCellLists = randomTraverser.FindAll(list => GetAvailableSpacesForWord(list, word).Count != 0);
                    var randomCellList = availableCellLists[Random.Range(0, availableCellLists.Count)];
                    var availableSpaces = GetAvailableSpacesForWord(randomCellList, word);
                    var randomSpace = availableSpaces[Random.Range(0, availableSpaces.Count)];

                    Debug.Log($"Found empty space for: {word} Space Length: {randomSpace.Count}");
                }
                catch (Exception)
                {
                    Debug.LogError($"Could not find available space for word: {word}");
                    break;
                }
            }
        }

        private List<List<Cell>> GetAvailableSpacesForWord(List<Cell> list, Word word)
        {
            var spaces = new List<List<Cell>>();

            for (int i = list.Count - word.Length + 1; i >= 0; i--)
            {
                spaces.Add(new());
                int wordIndex = 0;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j].Letter == word.GetCharAt(wordIndex) || list[j].Letter.Equals(Constants.EMPTY_LETTER))
                    {
                        spaces[^1].Add(list[j]);
                        wordIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            spaces.RemoveAll(space => space.Count == 0);
            return spaces;
        }

        public void FillWithRandomLetters(Grid grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    grid.GetCell(x, y).Letter = GetRandomChar();
                }
            }
        }

        public List<List<Cell>> GetRandomTraverser(Grid grid)
        {
            return new GridTraverser(grid, GetRandomTraverseMethod()).GetTraverseList();
        }

        private TraverseMethod GetRandomTraverseMethod()
        {
            var traverseMethods = Enum.GetNames(typeof(TraverseMethod));
            return Enum.Parse<TraverseMethod>(traverseMethods[Random.Range(0, traverseMethods.Length)]);
        }

        public List<List<Cell>> GetGridTraverser(Grid grid, TraverseMethod method)
        {
            return new GridTraverser(grid, method).GetTraverseList();
        }

        public char GetRandomChar()
        {
            return (char)('A' + Random.Range(0, 26));
        }
    }
}
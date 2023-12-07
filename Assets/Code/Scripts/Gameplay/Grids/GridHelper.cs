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
        private List<string> traverseMethods;

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
            int traverseMethodCount = Enum.GetNames(typeof(TraverseMethod)).Length;
            for (int i = 0; i < words.Count; i++)
            {
                var word = words[i];

                for (int t = 0; t < traverseMethodCount; t++)
                {
                    var randomTraverser = GetRandomTraverser(grid);

                    // Debug.Log($"{randomTraverser[0][0].X} {randomTraverser[0][0].Y} - {randomTraverser[^1][^1].X} {randomTraverser[^1][^1].Y}");

                    // Debug.Log(string.Join(" - ", randomTraverser.Select(rt => string.Join(",", rt.Select(cell => $"{cell.X}x{cell.Y}")))));

                    bool foundPlaceForWord = false;

                    try
                    {
                        var availableCellLists = randomTraverser.FindAll(list => GetAvailableSpacesForWord(list, word).Count != 0);

                        if (availableCellLists.Count == 0) continue;

                        var randomCellList = availableCellLists[Random.Range(0, availableCellLists.Count)];
                        var availableSpaces = GetAvailableSpacesForWord(randomCellList, word);

                        if (availableSpaces.Count == 0) continue;

                        var randomSpace = availableSpaces[Random.Range(0, availableSpaces.Count)];

                        for (int spaceIndex = 0; spaceIndex < randomSpace.Count; spaceIndex++)
                        {
                            randomSpace[spaceIndex].Letter = word.GetCharAt(spaceIndex);
                        }

                        foundPlaceForWord = true;
                        Debug.Log($"Found empty space for: {word.Content} Space Length: {randomSpace.Count}");
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                        Debug.LogError($"Could not find available space for word: {word.Content}");
                    }

                    if (foundPlaceForWord) break;
                }
            }
        }

        private List<List<Cell>> GetAvailableSpacesForWord(List<Cell> list, Word word)
        {
            var spaces = new List<List<Cell>>();

            if (word.Length > list.Count)
                return spaces;

            var startingIndex = Mathf.Clamp(list.Count - word.Length, 0, list.Count - 1);
            for (int i = startingIndex; i >= 0; i--)
            {
                spaces.Add(new());
                int wordIndex = 0;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j].Letter == word.GetCharAt(wordIndex) || list[j].Letter.Equals(Constants.EMPTY_LETTER))
                    {
                        // Debug.Log($"Cell: {list[j].X}x{list[j].Y} - " + word.GetCharAt(wordIndex));
                        spaces[^1].Add(list[j]);
                        wordIndex++;
                        if (wordIndex >= word.Length)
                        {
                            break;
                        }
                    }
                    else
                    {
                        spaces.RemoveAt(spaces.Count - 1);
                        break;
                    }
                }
            }

            var removed = spaces.RemoveAll(space => space.Count == 0);
            return spaces;
        }

        public void FillEmptyCellsWithRandomLetters(Grid grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    var cell = grid.GetCell(x, y);
                    if (cell.Letter.Equals(Constants.EMPTY_LETTER))
                    {
                        cell.Letter = GetRandomChar();
                    }
                }
            }
        }

        public List<List<Cell>> GetRandomTraverser(Grid grid)
        {
            return new GridTraverser(grid, GetRandomTraverseMethod()).GetTraverseList();
        }

        private TraverseMethod GetRandomTraverseMethod()
        {
            if (traverseMethods == null || traverseMethods.Count == 0)
            {
                traverseMethods = Enum.GetNames(typeof(TraverseMethod)).ToList();
            }

            var randomIndex = Random.Range(0, traverseMethods.Count);
            var method = Enum.Parse<TraverseMethod>(traverseMethods[randomIndex]);
            traverseMethods.RemoveAt(randomIndex);

            return method;
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
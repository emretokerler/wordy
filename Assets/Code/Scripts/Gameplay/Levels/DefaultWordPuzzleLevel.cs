using System.Collections.Generic;
using UnityEngine;
using Wordy.Events;
using Wordy.Grids;
using Wordy.UI.Events;
using Wordy.Words;
using Grid = Wordy.Grids.Grid;

namespace Wordy.Levels
{
    public class DefaultWordPuzzleLevel : LevelBase
    {
        private Grid currentGrid;
        private GridView currentGridView;
        public List<Word> LevelWords;
        public List<Cell> HighlightedCells;

        public override void InitializeLevel()
        {
            ClearPreviousGrid();

            currentGrid = gridHelper.CreateEmptyGrid(LevelConfig.GridWidth, LevelConfig.GridHeight);
            LevelWords = gridHelper.FillWithWords(currentGrid, wordsHelper.WordsLibrary);
            gridHelper.FillEmptyCellsWithRandomLetters(currentGrid);
            gridHelper.SpawnDefaultGridView(transform, OnGridViewSpawned);

            foreach (var w in LevelWords)
            {
                w.IsRevealed = false;
            }

            HighlightedCells = new();
        }

        private void ClearPreviousGrid()
        {
            if (currentGridView != null) Destroy(currentGridView.gameObject);
            currentGrid = null;
        }

        private void OnGridViewSpawned(GridView gridView)
        {
            currentGridView = gridView;
            currentGridView.Initialize(currentGrid);
            StartLevel();
        }

        public override void StartLevel()
        {
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.On<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.On<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.On<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);
            GameEvents.On<RefreshClickedEvent>(HandleRefreshClicked);
            GameEvents.On<FindClickedEvent>(HandleFindClicked);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.Off<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.Off<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.Off<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);
            GameEvents.Off<RefreshClickedEvent>(HandleRefreshClicked);
            GameEvents.Off<FindClickedEvent>(HandleFindClicked);
        }

        void HandleLevelWidthDecreased(LevelWidthDecreaseClickedEvent e)
        {
            LevelConfig.GridWidth--;
            InitializeLevel();
        }
        void HandleLevelWidthIncreased(LevelWidthIncreaseClickedEvent e)
        {
            LevelConfig.GridWidth++;
            InitializeLevel();
        }
        void HandleLevelHeightDecreased(LevelHeightDecreaseClickedEvent e)
        {
            LevelConfig.GridHeight--;
            InitializeLevel();
        }
        void HandleLevelHeightIncreased(LevelHeightIncreaseClickedEvent e)
        {
            LevelConfig.GridHeight++;
            InitializeLevel();
        }

        void HandleRefreshClicked(RefreshClickedEvent e)
        {
            InitializeLevel();
        }

        void HandleFindClicked(FindClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using Wordy.Events;
using Wordy.Grids;
using Wordy.UI.Events;
using Wordy.Utils;
using Wordy.Words;
using Wordy.Words.Events;
using Grid = Wordy.Grids.Grid;

namespace Wordy.Levels
{
    public class DefaultWordPuzzleLevel : LevelBase
    {
        [SerializeField] private LineRenderer wordHighlightLinePrefab;
        private List<LineRenderer> spawnedHighlightLines;
        private Grid currentGrid;
        private GridView currentGridView;
        public List<Word> LevelWords;

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
        }

        private void ClearPreviousGrid()
        {
            if (currentGridView != null) Destroy(currentGridView.gameObject);
            currentGrid = null;

            if (LevelWords != null)
            {
                foreach (var word in LevelWords)
                {
                    word.Cells.Clear();
                    word.Cells = null;
                }
            }
            LevelWords = new List<Word>();

            if (spawnedHighlightLines != null)
            {
                foreach (var line in spawnedHighlightLines)
                {
                    Destroy(line.gameObject);
                }
            }
            spawnedHighlightLines = new List<LineRenderer>();

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

        private void CreateHighlightLineForWord(Word word)
        {
            var line = Instantiate(wordHighlightLinePrefab, transform);
            spawnedHighlightLines.Add(line);

            var positions = new List<Vector3>();
            foreach (var cell in word.Cells)
            {
                positions.Add(new Vector3(cell.CellController.transform.position.x, 0.01f, cell.CellController.transform.position.z));
            }
            line.positionCount = positions.Count;
            line.SetPositions(positions.ToArray());

            var randomColor = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
            randomColor.a = 0.2f;
            line.material.SetColor(Constants.UNLIT_MATERIAL_COLOR_KEYWORD, randomColor);
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

            GameEvents.On<WordRevealedEvent>(HandleWordRevealed);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.Off<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.Off<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.Off<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);
            GameEvents.Off<RefreshClickedEvent>(HandleRefreshClicked);
            GameEvents.Off<FindClickedEvent>(HandleFindClicked);

            GameEvents.Off<WordRevealedEvent>(HandleWordRevealed);
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

        void HandleWordRevealed(WordRevealedEvent e)
        {
            CreateHighlightLineForWord(e.Word);
        }
    }
}
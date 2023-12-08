using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Wordy.Events;
using Wordy.Grids.Events;
using Wordy.Levels;
using Wordy.Levels.Events;
using Wordy.UI.Events;

namespace Wordy.UI
{
    public class UILevelConfig : MonoBehaviour
    {
        [SerializeField] private CanvasGroup bottomSectionGroup;
        [SerializeField] private Button widthDecreaseButton;
        [SerializeField] private Button widthIncreaseButton;
        [SerializeField] private Button heightDecreaseButton;
        [SerializeField] private Button heightIncreaseButton;
        [SerializeField] private Button wordCountDecreaseButton;
        [SerializeField] private Button wordCountIncreaseButton;
        [SerializeField] private Button wordLengthDecreaseButton;
        [SerializeField] private Button wordLengthIncreaseButton;
        [SerializeField] private Button findButton;
        [SerializeField] private Button refreshButton;

        [SerializeField] private TextMeshProUGUI currentWidthTxt;
        [SerializeField] private TextMeshProUGUI currentHeightTxt;
        [SerializeField] private TextMeshProUGUI currentWordCountTxt;
        [SerializeField] private TextMeshProUGUI currentWordLengthTxt;


        [SerializeField, Range(2, 29)] private int minWordCount;
        [SerializeField, Range(3, 30)] private int maxWordCount;

        [SerializeField, Range(2, 6)] private int minWordLength;
        [SerializeField, Range(3, 7)] private int maxWordLength;

        [SerializeField, Range(2, 8)] private int minGridSize;
        [SerializeField, Range(3, 10)] private int maxGridSize;

        private int currentGridWidth = 0;
        private int currentGridHeight = 0;
        private int currentWordCount = 0;
        private int currentWordLength = 0;

        private void Awake()
        {
            HideBottomSection();
            CreateEventSystem();
        }

        private void CreateEventSystem()
        {
            if (!EventSystem.current)
            {
                new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            }
        }

        private void ShowBottomSection()
        {
            bottomSectionGroup.alpha = 1;
        }

        private void HideBottomSection()
        {
            bottomSectionGroup.alpha = 0;
        }

        private void UpdateSelectors()
        {
            UpdateLevelWidthSelector();
            UpdateLevelHeightSelector();
            UpdateWordCountSelector();
            UpdateWordLengthSelector();
        }

        private void UpdateLevelWidthSelector()
        {
            widthDecreaseButton.interactable = currentGridWidth > minGridSize;
            widthIncreaseButton.interactable = currentGridWidth < maxGridSize;
            currentWidthTxt.text = currentGridWidth.ToString();
        }

        private void UpdateLevelHeightSelector()
        {
            heightDecreaseButton.interactable = currentGridHeight > minGridSize;
            heightIncreaseButton.interactable = currentGridHeight < maxGridSize;
            currentHeightTxt.text = currentGridHeight.ToString();
        }

        private void UpdateWordCountSelector()
        {
            wordCountDecreaseButton.interactable = currentWordCount > minWordCount;
            wordCountIncreaseButton.interactable = currentWordCount < maxWordCount;
            currentWordCountTxt.text = currentWordCount.ToString();
        }

        private void UpdateWordLengthSelector()
        {
            wordLengthDecreaseButton.interactable = currentWordLength > minWordLength;
            wordLengthIncreaseButton.interactable = currentWordLength < maxWordLength;
            currentWordLengthTxt.text = currentWordLength.ToString();
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            SetupClickListeners();

            GameEvents.On<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.On<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.On<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.On<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);

            GameEvents.On<WordCountDecreasedEvent>(HandleWordCountDecreased);
            GameEvents.On<WordCountIncreasedEvent>(HandleWordCountIncreased);
            GameEvents.On<WordLengthDecreasedEvent>(HandleWordLengthDecreased);
            GameEvents.On<WordLengthIncreasedEvent>(HandleWordLengthIncreased);

            GameEvents.On<GridViewInitializedEvent>(HandleGridViewInitialized);
            GameEvents.On<LevelInitializedEvent>(HandleLevelInitialized);
        }
        void UnregisterEvents()
        {
            RemoveClickListeners();

            GameEvents.Off<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.Off<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.Off<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.Off<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);

            GameEvents.Off<WordCountDecreasedEvent>(HandleWordCountDecreased);
            GameEvents.Off<WordCountIncreasedEvent>(HandleWordCountIncreased);
            GameEvents.Off<WordLengthDecreasedEvent>(HandleWordLengthDecreased);
            GameEvents.Off<WordLengthIncreasedEvent>(HandleWordLengthIncreased);


            GameEvents.Off<GridViewInitializedEvent>(HandleGridViewInitialized);
            GameEvents.Off<LevelInitializedEvent>(HandleLevelInitialized);
        }

        void SetupClickListeners()
        {
            widthDecreaseButton.onClick.AddListener(() => LevelWidthDecreaseClickedEvent.Trigger());
            widthIncreaseButton.onClick.AddListener(() => LevelWidthIncreaseClickedEvent.Trigger());

            heightDecreaseButton.onClick.AddListener(() => LevelHeightDecreaseClickedEvent.Trigger());
            heightIncreaseButton.onClick.AddListener(() => LevelHeightIncreaseClickedEvent.Trigger());

            wordCountDecreaseButton.onClick.AddListener(() => WordCountDecreasedEvent.Trigger());
            wordCountIncreaseButton.onClick.AddListener(() => WordCountIncreasedEvent.Trigger());

            wordLengthDecreaseButton.onClick.AddListener(() => WordLengthDecreasedEvent.Trigger());
            wordLengthIncreaseButton.onClick.AddListener(() => WordLengthIncreasedEvent.Trigger());

            heightDecreaseButton.onClick.AddListener(() => LevelHeightDecreaseClickedEvent.Trigger());
            heightIncreaseButton.onClick.AddListener(() => LevelHeightIncreaseClickedEvent.Trigger());


            findButton.onClick.AddListener(() => FindClickedEvent.Trigger());
            refreshButton.onClick.AddListener(() => RefreshClickedEvent.Trigger());
        }

        void RemoveClickListeners()
        {
            widthDecreaseButton.onClick.RemoveAllListeners();
            widthIncreaseButton.onClick.RemoveAllListeners();
            heightDecreaseButton.onClick.RemoveAllListeners();
            heightIncreaseButton.onClick.RemoveAllListeners();
            wordCountIncreaseButton.onClick.RemoveAllListeners();
            wordCountDecreaseButton.onClick.RemoveAllListeners();
            wordLengthIncreaseButton.onClick.RemoveAllListeners();
            wordLengthDecreaseButton.onClick.RemoveAllListeners();
            findButton.onClick.RemoveAllListeners();
            refreshButton.onClick.RemoveAllListeners();
        }

        void HandleLevelWidthDecreased(LevelWidthDecreaseClickedEvent e)
        {
            currentGridWidth--;
            UpdateLevelWidthSelector();
        }
        void HandleLevelWidthIncreased(LevelWidthIncreaseClickedEvent e)
        {
            currentGridWidth++;
            UpdateLevelWidthSelector();
        }
        void HandleLevelHeightDecreased(LevelHeightDecreaseClickedEvent e)
        {
            currentGridHeight--;
            UpdateLevelHeightSelector();
        }
        void HandleLevelHeightIncreased(LevelHeightIncreaseClickedEvent e)
        {
            currentGridHeight++;
            UpdateLevelHeightSelector();
        }
        void HandleWordCountIncreased(WordCountIncreasedEvent e)
        {
            currentWordCount++;
            UpdateWordCountSelector();
        }
        void HandleWordCountDecreased(WordCountDecreasedEvent e)
        {
            currentWordCount--;
            UpdateWordCountSelector();
        }
        void HandleWordLengthIncreased(WordLengthIncreasedEvent e)
        {
            currentWordLength++;
            UpdateWordLengthSelector();
        }
        void HandleWordLengthDecreased(WordLengthDecreasedEvent e)
        {
            currentWordLength--;
            UpdateWordLengthSelector();
        }

        void HandleGridViewInitialized(GridViewInitializedEvent e)
        {
            // currentGridWidth = e.GridView.GridWidth;
            // currentGridHeight = e.GridView.GridHeight;
            // UpdateSelectors();

            // ShowBottomSection();
        }

        void HandleLevelInitialized(LevelInitializedEvent e)
        {
            currentGridWidth = e.Level.LevelConfig.GridWidth;
            currentGridHeight = e.Level.LevelConfig.GridHeight;
            currentWordCount = e.Level.LevelConfig.WordCount;
            currentWordLength = e.Level.LevelConfig.WordLength;

            UpdateSelectors();
            ShowBottomSection();
        }
    }
}
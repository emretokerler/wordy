using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Wordy.Events;
using Wordy.Grids.Events;
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
        [SerializeField] private Button findButton;
        [SerializeField] private Button refreshButton;

        [SerializeField] private TextMeshProUGUI currentWidthTxt;
        [SerializeField] private TextMeshProUGUI currentHeightTxt;


        [SerializeField, Range(2, 8)] private int minGridSize;
        [SerializeField, Range(3, 10)] private int maxGridSize;

        private int currentGridWidth = 0;
        private int currentGridHeight = 0;

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

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            SetupClickListeners();

            GameEvents.On<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.On<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.On<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.On<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);

            GameEvents.On<GridViewInitializedEvent>(HandleGridViewInitialized);
        }
        void UnregisterEvents()
        {
            RemoveClickListeners();

            GameEvents.Off<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.Off<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.Off<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.Off<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);

            GameEvents.Off<GridViewInitializedEvent>(HandleGridViewInitialized);
        }

        void SetupClickListeners()
        {
            widthDecreaseButton.onClick.AddListener(() => LevelWidthDecreaseClickedEvent.Trigger());
            widthIncreaseButton.onClick.AddListener(() => LevelWidthIncreaseClickedEvent.Trigger());

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

        void HandleGridViewInitialized(GridViewInitializedEvent e)
        {
            currentGridWidth = e.GridView.GridWidth;
            currentGridHeight = e.GridView.GridHeight;
            UpdateLevelWidthSelector();
            UpdateLevelHeightSelector();
            ShowBottomSection();
        }
    }
}
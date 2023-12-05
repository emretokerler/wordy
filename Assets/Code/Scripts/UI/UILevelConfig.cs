using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wordy.UI.Events;

namespace Wordy.UI
{
    public class UILevelConfig : MonoBehaviour
    {
        [SerializeField] private Button widthDecreaseButton;
        [SerializeField] private Button widthIncreaseButton;
        [SerializeField] private Button heightDecreaseButton;
        [SerializeField] private Button heightIncreaseButton;
        [SerializeField] private Button findButton;
        [SerializeField] private Button refreshButton;


        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            SetupClickListeners();
        }
        void UnregisterEvents()
        {
            RemoveClickListeners();
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
    }
}
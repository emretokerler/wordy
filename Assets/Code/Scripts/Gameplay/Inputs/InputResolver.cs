using System.Collections.Generic;
using UnityEngine;
using Wordy.Gameplay.Inputs.Events;
using Wordy.Grids;
using Wordy.Utils;

namespace Wordy.Gameplay.Inputs
{
    public class InputResolver : MonoBehaviour
    {
        private Camera mainCamera => _mainCamera ??= FindObjectOfType<Camera>();
        private Camera _mainCamera;
        private List<CellController> highlightedCells;
        private CellController activeCell;
        private bool isClickedDown;

        private void Awake()
        {
            highlightedCells = new();
        }

        private bool GetRaycastHit(Vector2 screenPosition, out RaycastHit hit)
        {
            var ray = mainCamera.ScreenPointToRay(screenPosition);
            return Physics.Raycast(ray, out hit, 100);
        }

        private CellController GetCellUnderPointer(Vector2 screenPosition, out RaycastHit hit)
        {
            if (GetRaycastHit(screenPosition, out hit))
            {
                return hit.collider.GetComponentInParent<CellController>();
            }
            return null;
        }

        private void OnPointerDown(Vector2 screenPosition)
        {
            var cell = GetCellUnderPointer(screenPosition, out RaycastHit hit);

            if (cell != null)
            {
                isClickedDown = true;
                // cell.OnClickedDown(screenPosition);
            }
        }

        private void OnPointerMoved(Vector2 screenPosition)
        {
            var cell = GetCellUnderPointer(screenPosition, out RaycastHit hit);

            if (cell != null && cell != activeCell)
            {
                // cell.OnClickedDown(screenPosition);
                if (activeCell != null)
                {
                    var isNeighbour = cell.IsNeigbourTo(activeCell);
                    if (!isNeighbour) return;

                    if (highlightedCells.Count > 1)
                    {
                        Debug.Log((cell.transform.position - activeCell.transform.position));
                        Debug.Log(highlightedCells[1].transform.position - highlightedCells[0].transform.position);

                        if (new Vector2(cell.Cell.X, cell.Cell.Y) - new Vector2(activeCell.Cell.X, activeCell.Cell.Y) !=
                        new Vector2(highlightedCells[1].Cell.X, highlightedCells[1].Cell.Y) - new Vector2(highlightedCells[0].Cell.X, highlightedCells[0].Cell.Y)) return;
                    }

                }

                if (!highlightedCells.Contains(cell))
                {
                    cell.HighlightCell();
                    highlightedCells.Add(cell);
                    activeCell = cell;
                }
            }
        }

        private void OnPointerUp(Vector2 screenPosition)
        {
            isClickedDown = false;

            foreach (var c in highlightedCells)
            {
                c.UnhighlightCell();
            }

            OnPointerUpEvent.Trigger(new(highlightedCells));

            highlightedCells.Clear();
            activeCell = null;


            // var cell = GetCellUnderPointer(screenPosition, out RaycastHit hit);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnPointerDown(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                OnPointerMoved(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnPointerUp(Input.mousePosition);
            }
        }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
        }

        private void UnregisterEvents()
        {
        }
    }
}
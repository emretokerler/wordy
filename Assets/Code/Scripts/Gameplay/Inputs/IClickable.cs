using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wordy.Gameplay.Inputs
{
    public interface IClickable
    {
        void OnClickedDown(Vector2 screenPos, Vector3 worldPos);
        void OnClickedUp(Vector2 screenPos, Vector3 worldPos);
        void OnMouseOver(Vector2 screenPos, Vector3 worldPos);
    }
}

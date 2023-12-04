using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Wordy.Events;
using Wordy.Grids;
using Wordy.Grids.Events;

namespace Wordy.Gameplay.Cameras
{
    public class LevelCamera : MonoBehaviour
    {
        private CinemachineVirtualCamera vCam => _vCam ??= GetComponent<CinemachineVirtualCamera>(); private CinemachineVirtualCamera _vCam;

        private void CreateGroupComposerAccordingToGridView(GridView gridView)
        {
            var groupComposerParent = new GameObject("CinemachineGroupComposer").transform;

            var targetGroup = new GameObject(typeof(CinemachineTargetGroup).ToString()).AddComponent<CinemachineTargetGroup>();
            targetGroup.transform.SetParent(groupComposerParent);
            var points = gridView.GetCornerPoints();

            for (int i = 0; i < points.Count; i++)
            {
                var tMember = new GameObject($"CornerPoint-{i}").transform;
                tMember.SetParent(groupComposerParent);
                tMember.position = points[i];
                targetGroup.AddMember(tMember, 1, 0);
            }

            vCam.LookAt = targetGroup.transform;
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<GridViewInitializedEvent>(HandleGridViewInitialized);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<GridViewInitializedEvent>(HandleGridViewInitialized);
        }

        void HandleGridViewInitialized(GridViewInitializedEvent e)
        {
            CreateGroupComposerAccordingToGridView(e.GridView);
        }
    }
}
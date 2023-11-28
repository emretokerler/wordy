using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wordy.Resources
{
    public class Resources
    {
        private AsyncOperationHandle opHandle;
        void Load<T>(string path, Action OnComplete)
        {
            opHandle = Addressables.LoadAssetAsync<T>(path);

            opHandle.Completed += delegate
            {
                OnComplete?.Invoke();
            };
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wordy.Resources
{
    public class AddressableHelper
    {
        private static AsyncOperationHandle opHandle;
        public static void Load<T>(string path, Action<AsyncOperationHandle<T>> OnComplete)
        {
            AsyncOperationHandle<T> opHandle2;

            // opHandle2.Completed += OnComplete.;

            
            // opHandle = Addressables.LoadAssetAsync<T>(path);
            // opHandle.Completed += OnComplete;

        }

        public static void Instantiate<T>(string path, Action<AsyncOperationHandle> OnComplete)
        {
            opHandle = Addressables.InstantiateAsync(path);
            opHandle.Completed += OnComplete;
            
            // opHandle.Completed += delegate
            // {
            //     OnComplete?.Invoke(opHandle.);
            // };
        }

        public static WaitUntil Instantiate(AssetReference asset,
                                                Transform parent,
                                                Vector3 position,
                                                Quaternion rotation,
                                                Action<GameObject> callback)
        {
            var handle = Addressables.InstantiateAsync(asset, position, rotation, parent);

            handle.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    callback?.Invoke(handle.Result);
                }
                else
                {
                    callback?.Invoke(null);
                    Addressables.Release(handle);
                }
            };

            return new WaitUntil(() => handle.IsDone);
        }
    }
}
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Wordy.Resources
{
    public class AddressableHelper
    {
        public static void Load<T>(string path, Action<T> OnComplete)
        {
            var handle = Addressables.LoadAssetAsync<T>(path);
            handle.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    OnComplete?.Invoke(handle.Result);
                }
                else
                {
                    Addressables.Release(handle);
                }
            };
        }

        public static void Instantiate<T>(string path, Transform parent, Vector3 position, Quaternion rotation, Action<T> callback)
        {
            var handle = Addressables.InstantiateAsync(path, position, rotation, parent);

            handle.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    callback?.Invoke(handle.Result.GetComponent<T>());
                }
                else
                {
                    Addressables.Release(handle);
                }
            };
        }
    }
}
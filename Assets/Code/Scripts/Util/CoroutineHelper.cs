using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Services;

public class CoroutineHelper : SingletonMonobehaviour<CoroutineHelper>
{
    public static void Run(IEnumerator coroutine)
    {
        Instance.StartCoroutine(coroutine);
    }
}

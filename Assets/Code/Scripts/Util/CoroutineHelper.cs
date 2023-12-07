using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Services;

public class CoroutineHelper : SingletonMonobehaviour<CoroutineHelper>
{
    public static IEnumerator Run(IEnumerator coroutine)
    {
        yield return Instance.StartCoroutine(coroutine);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtoPhaseManager : MonoBehaviour
{
    public static event Action OnPoemStart;

    public static event Action OnEpochStart;


    private void Awake()
    {
        StartPoemPhase();

        ProtoSnippitTranslator.OnParseComplete += StartEpochPhase;
    }

    private void StartPoemPhase()
    {
        OnPoemStart?.Invoke();
    }

    private void StartEpochPhase()
    {
        OnEpochStart?.Invoke();
    }

    private void OnDestroy()
    {
        ProtoSnippitTranslator.OnParseComplete -= StartEpochPhase;

    }
}

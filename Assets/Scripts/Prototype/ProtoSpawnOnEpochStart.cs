using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoSpawnOnEpochStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ProtoPhaseManager.OnEpochStart += Spawn;
        ProtoPhaseManager.OnPoemStart += Despawn;
    }

    private void Spawn()
    {
        gameObject.SetActive(true);
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ProtoPhaseManager.OnEpochStart -= Spawn;
        ProtoPhaseManager.OnPoemStart -= Despawn;

    }
}

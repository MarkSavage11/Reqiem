using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(DragNDrop))]
public class ProtoSnippit : MonoBehaviour
{
    [SerializeField] private string _tag;

    public string Tag => _tag;

    private void Awake()
    {
        ProtoPhaseManager.OnEpochStart += Despawn;
    }

    private void Despawn()
    {

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ProtoPhaseManager.OnEpochStart -= Despawn;

    }
}

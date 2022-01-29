using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoSnippitManager : MonoBehaviour
{
    public static event Action<ProtoSnippit[]> OnSnippitsSubmit;

    [SerializeField] private Button submitButton;
    [SerializeField] private Collider2D snippitIntakeZone;


    private void Awake()
    {
        ProtoPhaseManager.OnPoemStart += SpawnSnippits;
        submitButton.onClick.AddListener(Submit);
    }

    private void SpawnSnippits()
    {
        submitButton.gameObject.SetActive(true);

    }

    private void Submit()
    {
        List<Collider2D> results = new List<Collider2D>();
        var contactFilter = new ContactFilter2D();
        var count = snippitIntakeZone.OverlapCollider(contactFilter.NoFilter(), results);
        List<ProtoSnippit> snippits = new List<ProtoSnippit>();
        foreach(Collider2D collider in results)
        {
            var snippit = collider.GetComponent<ProtoSnippit>();
            if (snippit) snippits.Add(snippit);
        }

        OnSnippitsSubmit?.Invoke(snippits.ToArray());
        submitButton.gameObject.SetActive(false);
    }



}

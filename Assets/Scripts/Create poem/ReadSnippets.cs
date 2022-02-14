using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadSnippets : MonoBehaviour
{
    public EpochData epochData;
    [SerializeField] private List<GameObject> panels;
    [SerializeField] private List<SnippitHolder> snippitHolders = new List<SnippitHolder>();
    [SerializeField] private Button submitButton;
    private List<SnippitData> snippetList = new List<SnippitData>();

    public event Action OnSubmit;

    private void Awake()
    {
        submitButton.onClick.AddListener(GetSnippets);

        //FOR NOW
        InitializeSnippitData();
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    //initializes all the snippit holders based on the Epoch Data
    public void InitializeSnippitData()
    {
        int index = 0;
        foreach(var snip in snippitHolders)
        {
            snip.gameObject.SetActive(index < epochData.SnippitPool.Count);
            if(index < epochData.SnippitPool.Count)
                snip.Initialize(epochData.SnippitPool[index]);
            index++;

        }
    }

    private void GetSnippets()
    {
        foreach (GameObject panel in panels)
        {
            // Loop through panels and return all snippets that are on panels (if any)
            PanelSettings panelSettings = panel.GetComponent<PanelSettings>();
            string panelId = panelSettings.Id;
            string snippetId = DragDropManager.GetPanelObject(panelId);

            // Find the corresponding snippet
            GameObject snippet = GameObject.Find(snippetId);


            // If the snippet exists, grab the text and put it in the snippet list. Otherwise, put in a blank spot
            if (snippet!= null)
            {
                
                snippetList.Add(snippet.GetComponent<SnippitHolder>().Identity);
            } else
            {
                snippetList.Add(null);
            }
        }

        epochData.LoadSnippits(snippetList);
        OnSubmit?.Invoke();
    }
}

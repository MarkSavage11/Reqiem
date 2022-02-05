using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadSnippets : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;
    [SerializeField] private Button submitButton;
    private List<string> snippetList = new List<string>();

    private void Awake()
    {
        submitButton.onClick.AddListener(GetSnippets);
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
            if (snippet != null)
            {
                GameObject snippetChild = snippet.gameObject.transform.GetChild(0).gameObject;
                string snippetText = snippetChild.GetComponent<TMP_Text>().text;
                snippetList.Add(snippetText);
            } else
            {
                snippetList.Add("");
            }
        }

        // Prints out each snippet in the snippet list to the console
        foreach (string snipp in snippetList)
        {
            Debug.Log(snipp);
        }

    }
}

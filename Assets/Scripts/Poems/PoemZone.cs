using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemZone : MonoBehaviour
{
    [SerializeField] private Collider2D zone;
    [SerializeField] private ReadSnippets poemManager;

    public static event System.Action OnPoemStart;
    public static event System.Action OnPoemComplete;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPoemStart?.Invoke();
            StartPoem();
        }
    }


    public void StartPoem()
    {
        //CompletePoem(); //Placeholder
        poemManager.Open();
        poemManager.OnSubmit += CompletePoem;
        poemManager.InitializeSnippitData();
    }

    public void CompletePoem()
    {
        poemManager.Close();
        poemManager.OnSubmit -= CompletePoem;
        OnPoemComplete?.Invoke();
    }
}

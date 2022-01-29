using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemZone : MonoBehaviour
{
    [SerializeField] private Collider2D zone;


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
        CompletePoem(); //Placeholder
    }

    public void CompletePoem()
    {
        OnPoemComplete?.Invoke();
    }
}

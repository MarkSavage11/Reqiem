using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneChunk : MonoBehaviour
{
    [SerializeField] protected Collider2D startBoundary;
    [SerializeField] protected Collider2D endBoundary;


    protected void StartBoundaryReached()
    {
        OnSceneBegin?.Invoke();
        
    }

    protected void EndBoundaryReached()
    {
        OnSceneComplete?.Invoke();
    }

    public virtual float GetWidth()
    {
        return endBoundary.transform.position.x - startBoundary.transform.position.x;
    }
    public abstract void LoadScene();

    public static event System.Action OnSceneComplete;

    public static event System.Action OnSceneBegin;
}

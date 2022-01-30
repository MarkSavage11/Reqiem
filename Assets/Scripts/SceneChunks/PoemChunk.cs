using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemChunk : SceneChunk
{
    [SerializeField] private EpochData epochData;
    [SerializeField] private PoemZone poemZone;
    private bool _showPoem;

    private void Awake()
    {

    }

    public override float GetWidth()
    {
        return endBoundary.transform.position.x - startBoundary.transform.position.x;

    }

    public override void LoadScene()
    {
        poemZone.gameObject.SetActive(_showPoem);
    }

    public void SetShowPoem(bool newValue)
    {
        _showPoem = newValue;
    }


}

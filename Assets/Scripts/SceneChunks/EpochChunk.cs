using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpochChunk : SceneChunk
{

    public override float GetWidth()
    {
        return endBoundary.transform.position.x - startBoundary.transform.position.x;
    }

    public override void LoadScene()
    {
        throw new System.NotImplementedException();
    }
}

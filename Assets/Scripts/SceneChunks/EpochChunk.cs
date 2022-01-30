using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpochChunk : SceneChunk
{
    [SerializeField] private EpochData epochData;

    List<SnipAss> snipAssets = new List<SnipAss>();

    private void Start()
    {
        snipAssets = new List<SnipAss>(GetComponentsInChildren<SnipAss>());
        foreach(SnipAss snip in snipAssets)
        {
            snip.gameObject.SetActive(false);
        }
    }


    public override float GetWidth()
    {
        return endBoundary.transform.position.x - startBoundary.transform.position.x;
    }

    public override void LoadScene()
    {
        foreach(SnipAss asset in snipAssets)
        {
            asset.gameObject.SetActive(epochData.GetUsedSnippitIDs().Contains(asset.SnippitID));
        }
    }
}

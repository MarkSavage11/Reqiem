using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EpochData : ScriptableObject
{
    public List<SnippitData> SnippitPool = new List<SnippitData>();

    public List<SnippitData> UsedSnippits = new List<SnippitData>();

    public PoemData PoemOutput;

    public List<string> GetUsedSnippitIDs()
    {
        List<string> result = new List<string>();
        foreach(var snip in UsedSnippits)
        {
            result.Add(snip.UID);
        }

        return result;
    }

    private void Awake()
    {
        UsedSnippits.Clear();
    }

}

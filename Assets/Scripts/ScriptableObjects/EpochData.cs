using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EpochData : ScriptableObject
{
    public List<SnippitData> SnippitPool = new List<SnippitData>();
    [System.NonSerialized]
    public List<SnippitData> UsedSnippits = new List<SnippitData>();

    public PoemData PoemOutput;

    public List<string> GetUsedSnippitIDs()
    {
        List<string> result = new List<string>();
        foreach(var snip in UsedSnippits)
        {
            if (snip == null) continue;
            result.Add(snip.UID);
        }

        return result;
    }

    public int LoadSnippits(List<SnippitData> snippits)
    {
        UsedSnippits = new List<SnippitData>();
        //PoemOutput.lines.Clear();
        foreach(var snip in snippits)
        {
            //TODO: Handle Poem
            //PoemOutput.lines.Add(snip);
            if (snip)
                UsedSnippits.Add(snip);
        }

        return UsedSnippits.Count;
    }

    private void OnDisable()
    {
        UsedSnippits = new List<SnippitData>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable object representing a Poem in the format that the player submitted. Nulls are OKay and expected
[CreateAssetMenu]
public class PoemData : ScriptableObject
{
    public List<SnippitData[]> lines;

    public string AsString()
    {
        string result = "";
        foreach(var line in lines)
        {
            foreach(var snippit in line)
            {
                if(snippit == null)
                {
                    result += "     ";
                }
                else
                {
                    result += snippit.AsString();
                }
            }
            result += "\n";
        }

        return result;
    }
}

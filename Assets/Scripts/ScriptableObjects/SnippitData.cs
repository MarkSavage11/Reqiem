using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SnippitData : ScriptableObject
{
    public string UID;
    public string Text;
    public Font Font;

    public string AsString()
    {
        return string.Format("<font=\"{0}\">{1}</font>", Font.fontNames[0], Text);
    }
}

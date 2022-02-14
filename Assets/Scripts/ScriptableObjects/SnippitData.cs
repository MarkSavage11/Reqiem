using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SnippitData : ScriptableObject
{
    public string UID;
    public string Text;
    public TMPro.TMP_FontAsset Font;

    public string AsString()
    {
        return Text;
        //TODO: GET FONTS WORKING
        //return string.Format("<font=\"{0}\">{1}</font>", Font.faceInfo.familyName, Text);
    }
}

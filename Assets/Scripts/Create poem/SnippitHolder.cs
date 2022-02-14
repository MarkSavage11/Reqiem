using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnippitHolder : MonoBehaviour
{
    [HideInInspector]
    private SnippitData _identity;
    [SerializeField] private TMP_Text textDisplay;

    public SnippitData Identity => _identity;
   public void Initialize(SnippitData identity)
    {
        this._identity = identity;

        textDisplay.text = identity.AsString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoSnippitTranslator : MonoBehaviour
{
    [SerializeField] private SnippitKeyPair[] SnippitDictionary;

    private Dictionary<string, GameObject> tagDictionary = new Dictionary<string, GameObject>();

    public static event System.Action OnParseComplete;

    private void Awake()
    {
        ProtoSnippitManager.OnSnippitsSubmit += ParseSnippits;
    }

    private void Start()
    {
        foreach(var skp in SnippitDictionary)
        {
            tagDictionary.Add(skp.snippitTag, skp.taggedAsset);
        }
    }

    private void ParseSnippits(ProtoSnippit[] snippits)
    {
        foreach(var snippit in snippits)
        {
            if (tagDictionary.ContainsKey(snippit.Tag))
            {
                tagDictionary[snippit.Tag].gameObject.SetActive(true);
            }
        }

        OnParseComplete?.Invoke();
    }

    private void OnDestroy()
    {
        ProtoSnippitManager.OnSnippitsSubmit -= ParseSnippits;

    }

    [System.Serializable]
    public struct SnippitKeyPair
    {
        public string snippitTag;
        public GameObject taggedAsset;
    }
}

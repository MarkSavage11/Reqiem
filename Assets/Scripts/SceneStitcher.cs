using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStitcher : MonoBehaviour
{

    [SerializeField] private SharkCharacter player;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private List<ChunkPair> Sequence = new List<ChunkPair>();
    [SerializeField] private AudioManager audioManager;

    private List<SceneChunk> loadedChunks = new List<SceneChunk>();
    private List<ChunkPair> loadedEpochPairs = new List<ChunkPair>();

    private int sequenceIndex = 0;

    private ChunkPair currentEpoch;

    private int epochIndex = 0;  // index that indicates if we're on the current Poem (0), or the current Epoch (1) Binary only

    private Vector2 positionToLoad;

    private void Awake()
    { 
        SceneChunk.OnSceneComplete += TransitionNext;
        PoemZone.OnPoemComplete += InitializeEpoch;
    }

    private void Start()
    {
        positionToLoad = startPosition;
        PlaceAllChunks();
        currentEpoch = loadedEpochPairs[0];

        audioManager.StartMusic();
    }


    private void PlaceAllChunks()
    {
        foreach(var chunks in Sequence)
        {
            PlaceNextChunkPair();
        }
        sequenceIndex = 0; //we are gonna reuse this index for tracking player progress
    }

    private void PlaceNextChunkPair()
    {
        ChunkPair chunksToLoad = Sequence[sequenceIndex];

        if (chunksToLoad.poem.isActiveAndEnabled)
        {
            chunksToLoad.poem.transform.position = positionToLoad + new Vector2(chunksToLoad.poem.GetWidth()/2,0);
        }
        else
        {
            chunksToLoad.poem = Instantiate(chunksToLoad.poem);
            chunksToLoad.poem.transform.position = positionToLoad + new Vector2(chunksToLoad.poem.GetWidth() / 2, 0);

        }

        if (chunksToLoad.epoch.isActiveAndEnabled)
        {
            chunksToLoad.epoch.transform.position = positionToLoad + new Vector2(chunksToLoad.poem.GetWidth() + chunksToLoad.epoch.GetWidth() / 2, 0);
        }
        else
        {
            chunksToLoad.epoch = Instantiate(chunksToLoad.epoch);
            chunksToLoad.epoch.transform.position = positionToLoad + new Vector2(chunksToLoad.poem.GetWidth() + chunksToLoad.epoch.GetWidth()/2, 0);

        }

        loadedChunks.Add(chunksToLoad.poem);
        loadedChunks.Add(chunksToLoad.epoch);
        loadedEpochPairs.Add(chunksToLoad);
        positionToLoad = new Vector2(positionToLoad.x + chunksToLoad.TotalWidth, positionToLoad.y);
        sequenceIndex++;
    }

    private void TransitionNext()
    {
        epochIndex++;
        if(epochIndex > 1)
        {
            epochIndex = 0;
            sequenceIndex++;
            if(sequenceIndex >= Sequence.Count)
            {
                LoopPlayer();
            }
            else
            {
                currentEpoch = loadedEpochPairs[sequenceIndex];
            }
            audioManager.AddLayer();
        }
    }

    private void InitializeEpoch()
    {
        currentEpoch.epoch.LoadScene();
    }

    private void LoopPlayer()
    {
        player.transform.position = startPosition;
        sequenceIndex = 0;

    }

    private void OnDestroy()
    {
        SceneChunk.OnSceneComplete -= TransitionNext;
        PoemZone.OnPoemComplete -= InitializeEpoch;

    }

}


[Serializable]
public struct ChunkPair
{
    public PoemChunk poem;
    public EpochChunk epoch;

    public float TotalWidth => poem.GetWidth() + epoch.GetWidth();
}
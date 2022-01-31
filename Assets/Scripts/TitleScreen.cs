using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BeauRoutine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Image title;
    [SerializeField] private Image pressToPlay;
    [SerializeField] private Fader fader;
    [SerializeField] private AudioManager audioManager;

    Routine pulseRoutine;

    private void Start()
    {
        enabled = false;
        title.SetAlpha(0f);
        pressToPlay.SetAlpha(0f);
        Routine.Start(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return 1.5f;
        yield return title.FadeTo(1, 2.5f);
        yield return pressToPlay.FadeTo(.25f, 1f);
        enabled = true;
        yield return pressToPlay.FadeTo(.5f, 1f);
        pulseRoutine.Replace(Pulse());


    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Routine.Start(LoadRoutine());
        }
    }

    private IEnumerator LoadRoutine()
    {
        yield return fader.FadeOutRoutine();
        pulseRoutine.Stop();
        SceneManager.LoadScene("GameplayScene");
    }

    private IEnumerator Pulse()
    {
        yield return pressToPlay.FadeTo(.7f, .75f);
        yield return pressToPlay.FadeTo(.3f, 2.5f).YoyoLoop();
    }
}

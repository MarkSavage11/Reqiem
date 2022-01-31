using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeauRoutine;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image faderImage;
    [SerializeField] private float fadeTime;
    [SerializeField] private bool startBlack;

    private void OnEnable()
    {
        faderImage.SetAlpha(startBlack ? 1 : 0);
    }

    //Fade from black
    public void FadeIn()
    {
        Routine.Start(faderImage.FadeTo(0, fadeTime));
    }

    //Fade to Black
    public void FadeOut()
    {
        Routine.Start(faderImage.FadeTo(1, fadeTime));
    }

    public IEnumerator FadeInRoutine()
    {
        yield return faderImage.FadeTo(0, fadeTime);

    }

    public IEnumerator FadeOutRoutine()
    {
        yield return faderImage.FadeTo(1, fadeTime);

    }

}

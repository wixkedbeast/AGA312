using UnityEngine;
using DG.Tweening;

public class SplashFader : MonoBehaviour
{
    float fadeTime = 0.5f;

    public void FadeIn(CanvasGroup _cvg)
    {
        _cvg.DOFade(1, fadeTime);
    }

    public void FadeOut(CanvasGroup _cvg)
    {
        _cvg.DOFade(0, fadeTime);
    }
}

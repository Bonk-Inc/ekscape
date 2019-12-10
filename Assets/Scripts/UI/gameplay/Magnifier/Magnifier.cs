using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnifier : MonoBehaviour
{

    [SerializeField]
    private RawImage imageRenderer;

    public static Magnifier Instance { get; private set; } 

    private FloatLerper lerper = new FloatLerper(0, 1, 10);
    private Coroutine fadeRoutine;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

    }

    public void Magnify(Magnifiable obj)
    {
        imageRenderer.enabled = true;
        imageRenderer.texture = obj.GetImage();
        imageRenderer.color = obj.GetColor();
    }

    public void MagnifyFadeIn(Magnifiable obj)
    {
        Magnify(obj);
        lerper.StartValue = 0;
        lerper.EndValue = obj.GetColor().a;
        StopLerpCoroutine();

        var fadeIn = lerper.LerpValue(SetImageColorAlpha, StopLerpCoroutine);
        fadeRoutine = StartCoroutine(fadeIn);
    }

    public void StopMagnify()
    {
        imageRenderer.enabled = false;
    }

    public void MagnifyFadeOut()
    {
        lerper.StartValue = imageRenderer.color.a;
        lerper.EndValue = 0;
        StopLerpCoroutine();

        var fadeOut = lerper.LerpValue(SetImageColorAlpha, StopLerpCoroutine);
        fadeRoutine = StartCoroutine(fadeOut);

    }

    private void SetImageColorAlpha(float alpha)
    {
        var color = imageRenderer.color;
        color.a = alpha;
        imageRenderer.color = color;
    }

    private void StopLerpCoroutine()
    {
        if (fadeRoutine == null)
            return;

        StopCoroutine(fadeRoutine);
        fadeRoutine = null;
    }



}

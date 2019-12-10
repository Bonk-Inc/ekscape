using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnifier : MonoBehaviour
{

    private static Magnifier instance;

    [SerializeField]
    private RawImage imageRenderer;

    public static Magnifier Instance => instance;

    private FloatLerper lerper = new FloatLerper(0, 1, 10);

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;

    }

    public void Magnify(Magnifiable obj)
    {
        imageRenderer.enabled = true;
        imageRenderer.texture = obj.GetImage();
        imageRenderer.color = obj.GetColor();
    }

    public void MagnifyFade(Magnifiable obj)
    {
        Magnify(obj);
        lerper.StartValue = 0;
        lerper.EndValue = obj.GetColor().a;

        StartCoroutine(lerper.LerpValue((value) => {
            SetImageColorAlpha(value);
        }));
    }

    public void StopMagnify()
    {
        imageRenderer.enabled = false;
    }

    public void StopMagnifyAlpha()
    {
        lerper.StartValue = imageRenderer.color.a;
        lerper.EndValue = 0;

        StartCoroutine(lerper.LerpValue((value) => {
            SetImageColorAlpha(value);
        }));

    }

    private void SetImageColorAlpha(float alpha)
    {
        var color = imageRenderer.color;
        color.a = alpha;
        imageRenderer.color = color;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifiable : MonoBehaviour
{
    [SerializeField]
    private Texture image;

    [SerializeField]
    private Color color = Color.white;

    public virtual Texture GetImage()
    {
        return image;
    }

    public virtual Color GetColor()
    {
        return color;
    }

}

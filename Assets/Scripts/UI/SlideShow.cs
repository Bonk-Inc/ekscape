using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private string[] names;

    private int current = 0;
    public void Back()
    {
        current = current == 0 ? sprites.Length -1 : current - 1;
        image.sprite = sprites[current];
        text.text = names[current];
    }

    public void Next()
    {
        current = current == sprites.Length -1 ? 0 : current + 1;
        image.sprite = sprites[current];
        text.text = names[current];
    }
}

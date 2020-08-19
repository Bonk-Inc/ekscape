using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup thisObject;

    [SerializeField]
    private float fadeSpeed = 0.05f;

    public void TriggerMenu(CanvasGroup menu = null, bool enterMenu = true)
    {
        Time.timeScale = enterMenu ? 0 : 1;

        if (menu != null)
        {
            if (enterMenu)
                StartCoroutine(FadeInGroup(menu));
            else menu.gameObject.SetActive(enterMenu);
        }
    }

    public void TriggerSelf(bool enterMenu = true)
    {
        TriggerMenu(thisObject, enterMenu);
    }

    private IEnumerator FadeInGroup(CanvasGroup menu)
    {
        menu.gameObject.SetActive(true);
        menu.alpha = 0;
        while (menu.alpha <= 0.95f)
        {
            menu.alpha += fadeSpeed;
            yield return null;
        }
        menu.alpha = 1;
    }
}

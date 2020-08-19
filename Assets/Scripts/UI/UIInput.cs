using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInput : MonoBehaviour
{
    [SerializeField]
    private GameMenu menuManager;

    [SerializeField]
    private CanvasGroup optionMenu;

    private GameObject previouslyOpened = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu(optionMenu);
        }
    }

    private void OpenMenu(CanvasGroup menu)
    {
        menuManager.TriggerMenu(menu, !menu.gameObject.activeInHierarchy);
        if(previouslyOpened != menu.gameObject)
        {
            previouslyOpened?.SetActive(false);
            previouslyOpened = menu.gameObject;
        }
    }
}

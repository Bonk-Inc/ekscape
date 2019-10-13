using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButtonHandler : MonoBehaviour
{

    [SerializeField]
    private Button quitButton;



    private void Awake()
    {
#if !UNITY_WEBGL && !UNITY_EDITOR
        quitButton.onClick.AddListener(Quit);
#else
        quitButton.gameObject.SetActive(false);
#endif
    }


    public void Quit()
    {
        Application.Quit();
    }

}

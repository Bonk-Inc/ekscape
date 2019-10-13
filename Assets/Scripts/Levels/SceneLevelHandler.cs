using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelHandler : MonoBehaviour
{

    private const string SceneLevelPrefix = "Play_Level_";
    private const string LastLevelSave = "Last Level";

    [SerializeField]
    private int SceneLevel;

    [SerializeField]
    private bool gameOptions = true;

    public string SceneName => GetSceneLevelName(SceneLevel);

    private void Awake()
    {
        if (gameOptions)
        {
            PlayerPrefs.SetInt(LastLevelSave, SceneLevel);
        }
    }

    public void LoadNextLevel()
    {
        if (!NextLevelExists())
            return;

        SceneManager.LoadScene(GetSceneLevelName(SceneLevel + 1));
    }

    private bool NextLevelExists()
    {
        var nextScene = SceneManager.GetSceneByName(GetSceneLevelName(SceneLevel + 1));
        return nextScene != null;
    }

    private string GetSceneLevelName(int level)
    {
        return SceneLevelPrefix + level;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !Input.GetKeyDown(KeyCode.W))
            return;

        LoadNextLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameOptions)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

}

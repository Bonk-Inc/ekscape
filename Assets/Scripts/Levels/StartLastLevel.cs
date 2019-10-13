using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLastLevel : MonoBehaviour
{
    private const string lastLevelSave = "Last Level";
    private const string sceneLevelPrefix = "Play_Level_";

    public void StartLevel()
    {
        if (!HasLastLevel())
            return;

        int lastLevel = PlayerPrefs.GetInt(lastLevelSave);
        SceneManager.LoadScene(sceneLevelPrefix + lastLevel);
    }

    public bool HasLastLevel()
    {
        return PlayerPrefs.HasKey(lastLevelSave);
    }

    [ContextMenu("Reset Level")]
    public void ResetLevel()
    {
        PlayerPrefs.DeleteKey(lastLevelSave);
    }

}

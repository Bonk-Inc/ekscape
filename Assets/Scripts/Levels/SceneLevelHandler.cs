using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelHandler : MonoBehaviour
{

    private const string SceneLevelPrefix = "Play_Level_";
    private const string LastLevelSave = "Last Level";

    [SerializeField]
    private string sceneLevel, defaultDoor;

    [SerializeField]
    private bool gameOptions = true;

    [SerializeField]
    private bool SkipPlayerPrefDoor = false;

    [SerializeField]
    private DestinationInfo playerPreset;

    [SerializeField]
    private DoorPassage[] doors;

    public event Action<Transform> OnPlayerSetup;

    private DestinationInfo destinationInfo;

    public string SceneName => GetSceneLevelName(sceneLevel);

    private void OnEnable()
    {
        destinationInfo = LocatePlayer();

        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SceneLevelHandler = this;
        }

        if (!FindDoor()) FindDoor(defaultDoor);

        if (gameOptions)
        {
            PlayerPrefs.SetString(LastLevelSave, sceneLevel);
        }
    }

    private DestinationInfo LocatePlayer()
    {
        DestinationInfo player = FindObjectOfType<DestinationInfo>();
        if (player == null)
        {
            player = Instantiate(playerPreset);
        }
        OnPlayerSetup(player.transform);
        return player;
    }

    private bool FindDoor()
    {
        string destination = destinationInfo.GetDoorDestination(SkipPlayerPrefDoor);
        
        return FindDoor(destination);
    }

    private bool FindDoor(string destination)
    {
        bool transported = false;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].DoorName == destination)
            {
                destinationInfo.transform.position = doors[i].transform.position;
                transported = true;
            }
        }
        return transported;
    }

    public void LoadNextLevel(string levelDestination, string doorDestination)
    {
        if (!NextLevelExists(levelDestination)) 
            return;

        destinationInfo.SetDestination(doorDestination, gameObject);

        if (IsSameLevel(levelDestination))
        {
            FindDoor();
        }
        else
        {
            SceneManager.LoadScene(GetSceneLevelName(levelDestination));
        }

    }

    private bool NextLevelExists(string levelDestination)
    {
        var nextScene = SceneManager.GetSceneByName(GetSceneLevelName(levelDestination));
        return nextScene != null;
    }

    private bool IsSameLevel(string levelDestination)
    {
        return sceneLevel.Equals(levelDestination);
    }

    private string GetSceneLevelName(string level)
    {
        return SceneLevelPrefix + level;
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameOptions)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

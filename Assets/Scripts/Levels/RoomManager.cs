using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    private const string LastRoomCheckpoint = "Last Room";
    private const string SceneLevelPrefix = "Play_Level_";
    
    [SerializeField]
    private bool isCheckpoint = false;
    
    [SerializeField]
    private int currentRoom;

    private void Awake()
    {
        if (isCheckpoint)
        {
            PlayerPrefs.SetInt(LastRoomCheckpoint, currentRoom);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SendToRoom(currentRoom);
        }
    }

    private bool LevelExists(int roomNumber)
    {
        var nextScene = SceneManager.GetSceneByName(GetSceneLevelName(roomNumber));
        return nextScene != null;
    }

    private string GetSceneLevelName(int level)
    {
        return SceneLevelPrefix + level;
    }

    public void SendToRoom(int roomNumber)
    {
        if(LevelExists(roomNumber))
            SceneManager.LoadScene(GetSceneLevelName(roomNumber));
    }
}

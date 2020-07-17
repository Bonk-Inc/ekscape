using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationInfo : MonoBehaviour
{
    private const string LastDoorSave = "Last Door";

    private string doorDestination = "";

    public string DoorDestination => doorDestination;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public string GetDoorDestination(bool skipPlayerPrefs = false)
    {
        if(doorDestination == "" && !skipPlayerPrefs)
        {
            doorDestination = PlayerPrefs.GetString(LastDoorSave);
        }
        return doorDestination;
    }

    public void SetDestination(string doorDestination, bool gameOptions = false)
    {
        this.doorDestination = doorDestination;
        if (gameOptions)
        {
            PlayerPrefs.SetString(LastDoorSave, doorDestination);
        }
    }

}

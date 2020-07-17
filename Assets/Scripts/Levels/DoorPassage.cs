using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPassage : MonoBehaviour
{
    [SerializeField]
    private string doorName;

    [SerializeField]
    private string levelDestinationName;

    [SerializeField]
    private string DoorDestinationName;

    private SceneLevelHandler sceneLevelHandler;

    public string DoorName => doorName;

    public SceneLevelHandler SceneLevelHandler { get => sceneLevelHandler; set => sceneLevelHandler = value; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !Input.GetKeyDown(KeyCode.W))
            return;

        SceneLevelHandler.LoadNextLevel(levelDestinationName, DoorDestinationName);
    }

    
}

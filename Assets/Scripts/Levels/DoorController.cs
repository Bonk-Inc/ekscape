using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private const string SceneLevelPrefix = "Play_Level_";

    [SerializeField]
    private RoomManager room;

    [SerializeField]
    private int roomDestination;

    [SerializeField]
    private bool isCheckpoint = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !Input.GetKeyDown(KeyCode.W))
            return;

        room.SendToRoom(roomDestination);
    }
}

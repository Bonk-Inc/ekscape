using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomHandler : MonoBehaviour
{

    [SerializeField]
    private Collider2D level;

    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraPosition(level.bounds.center);
        float size = 0;
        if(level.bounds.size.x / level.bounds.size.y < camera.aspect)
        {
            size = level.bounds.size.y;
        }
        else
        {
            size = level.bounds.size.y / camera.aspect * (level.bounds.size.x / level.bounds.size.y);
        }
        camera.orthographicSize = size / 2;
    }

    private void SetCameraPosition(Vector2 pos)
    {
        var camPos = camera.transform.position; 
        camPos.x = pos.x;
        camPos.y = pos.y;
        camera.transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

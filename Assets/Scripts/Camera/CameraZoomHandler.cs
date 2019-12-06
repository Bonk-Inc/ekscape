using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomHandler : MonoBehaviour
{

    [SerializeField]
    private Collider2D level;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float lerpSpeed = 10;

    private Coroutine zoomRoutine;

    public bool IsZoomOut => zoomRoutine != null;

    public void StartZoom()
    {
        if (IsZoomOut)
            return;

        zoomRoutine = StartCoroutine(ZoomOut());
    }

    public void StopZoom()
    {
        if (!IsZoomOut)
            return;

        StopCoroutine(zoomRoutine);
        zoomRoutine = null;
    }

    private IEnumerator ZoomOut()
    {
        while (true)
        {
            float size = GetSize();
            Vector2 position = GetPosition();

            SetCameraPosition(Vector2.Lerp(camera.transform.position, position, lerpSpeed * Time.deltaTime));
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, lerpSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private void SetCameraPosition(Vector2 pos)
    {
        var camPos = camera.transform.position;
        camPos.x = pos.x;
        camPos.y = pos.y;
        camera.transform.position = camPos;
    }


    private Vector2 GetPosition()
    {
        return level.bounds.center;
    }

    private float GetSize()
    {
        float size;
        if (level.bounds.size.x / level.bounds.size.y < camera.aspect)
        {
            size = level.bounds.size.y;
        }
        else
        {
            float levelAspect = (level.bounds.size.x / level.bounds.size.y);
            size = level.bounds.size.y / camera.aspect * levelAspect;
        }
        return size / 2;
    }
}

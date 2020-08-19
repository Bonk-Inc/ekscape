using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomHandler : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float lerpSpeed = 10;

    [SerializeField]
    private float margin;

    [SerializeField]
    private float minZoom;

    private Coroutine zoomRoutine;

    [SerializeField]
    private Bounds bounds;

    public bool IsZoomOut => zoomRoutine != null;

    public void SetBounds(Bounds newBounds)
    {
        bounds = newBounds;
    }

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
            yield return null;
            float size = GetSize() + margin;
            Vector2 position = GetPosition();

            size = Mathf.Max(minZoom, size);

            SetCameraPosition(Vector2.Lerp(camera.transform.position, position, lerpSpeed * Time.deltaTime));
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, lerpSpeed * Time.deltaTime);

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
        return bounds.center;
    }

    private float GetSize()
    {
        float size;
        if (bounds.size.x / bounds.size.y < camera.aspect)
        {
            size = bounds.size.y;
        }
        else
        {
            float levelAspect = (bounds.size.x / bounds.size.y);
            size = bounds.size.y / camera.aspect * levelAspect;
        }
        return size / 2;
    }
}

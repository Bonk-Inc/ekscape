using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private float zoomLerpMargin = 0.0023f;

    private Coroutine zoomRoutine;

    public void ZoomTo(float zoom, Action onZoomCompleted = null)
    {
        zoomRoutine = StartCoroutine(ZoomToRoutine(zoom, onZoomCompleted));
    }

    public void StopZoom()
    {
        if (zoomRoutine == null)
            return;

        StopCoroutine(zoomRoutine);
        zoomRoutine = null;
    }

    private IEnumerator ZoomToRoutine(float zoom, Action onZoomCompleted = null)
    {
        while(Mathf.Abs(zoom - camera.orthographicSize) > zoomLerpMargin)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom, lerpSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        camera.orthographicSize = zoom;
        onZoomCompleted?.Invoke();
    }
    
}

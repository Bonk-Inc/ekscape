using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grapple : MonoBehaviour {
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Rigidbody2D grabPoint;

    [SerializeField]
    private float maxLength = 1;

    [SerializeField]
    private float throwTime = 0.5f;

    [SerializeField]
    private Rigidbody2D playerRigid;

    private Vector3 lastHookPoint;
    private Coroutine ChangeLineRoutine;

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && playerRigid.velocity == Vector2.zero) {
            SendHook();
        }
    }

    private void SendHook() {
        Vector3 startPoint = transform.position;
        Vector3 goalPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ChangeLineRoutine = StartCoroutine(ChangeLine(startPoint, goalPoint, throwTime, () => {
            grabPoint.position = transform.position;
            ClearPositionCount();
        }));
    }

    private IEnumerator ChangeLine(Vector3 startPoint, Vector3 goalPoint, float totalTime, Action OnFinish = null) {
        var maxLineLenght = Mathf.Min((goalPoint - startPoint).magnitude, maxLength);
        Vector3 currentEndPoint = Vector3.zero;
        float timeDuration = 0;
        ChangePositionCount(2);

        while (timeDuration <= totalTime) {
            if (!Input.GetMouseButton(0))break;
            timeDuration += Time.deltaTime;
            float hookLength = maxLineLenght / totalTime * timeDuration;

            currentEndPoint = CalculateEndPoint(startPoint, goalPoint, hookLength);
            SetLine(currentEndPoint);
            lastHookPoint = currentEndPoint;

            yield return null;
        }
        SetLine(currentEndPoint);
        OnFinish?.Invoke();
    }

    private Vector3 CalculateEndPoint(Vector3 originPoint, Vector3 wantedPosition, float distance) {
        Vector3 endPoint = Vector3.Normalize(wantedPosition - originPoint) * distance + originPoint;
        return endPoint;
    }

    public void SetLine(Vector3 destination) {
        if(lineRenderer.positionCount == 0) return;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, destination);
        grabPoint.position = destination;
    }

    private void ChangePositionCount(int lines) {
        lineRenderer.positionCount = lines;
        grabPoint.gameObject.SetActive(lines > 0);
    }

    public void ClearPositionCount() {
        ChangePositionCount(0);
    }

    public void StopRoutine() {
        StopCoroutine(ChangeLineRoutine);
    }
}
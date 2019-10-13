using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private Rigidbody2D grabPoint;
    
    [SerializeField]
    private float maxLength = 1;

    [SerializeField]
    private float throwTime = 0.5f;

    private Vector3 lastHookPoint;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            SendHook();
        }
    }

    private void SendHook(){
        Vector3 startPoint = transform.position;
        Vector3 goalPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(ChangeLine(startPoint, goalPoint, throwTime, ()=> {
            grabPoint.position = transform.position;
            ChangePositionCount(0); 
        }));
    }

    private IEnumerator ChangeLine(Vector3 startPoint, Vector3 goalPoint, float totalTime, Action OnFinish = null){
        Vector3 currentEndPoint = Vector3.zero;
        float timeDuration = 0;
        ChangePositionCount(2);

        while(Input.GetMouseButton(0)){
            while(timeDuration <= totalTime){
                if(!Input.GetMouseButton(0)) break;
                timeDuration += Time.deltaTime;
                float hookLength = maxLength / totalTime * timeDuration;

                currentEndPoint = CalculateEndPoint(startPoint, goalPoint, hookLength);
                SetLine(currentEndPoint);
                
                yield return null;    
            }
            SetLine(currentEndPoint);
            yield return null;
        }
        lastHookPoint = currentEndPoint;
        
        if(OnFinish != null){
            OnFinish();
            OnFinish = null;
        }
    }


    private Vector3 CalculateEndPoint(Vector3 originPoint, Vector3 wantedPosition, float distance){
        Vector3 endPoint = Vector3.Normalize(wantedPosition - originPoint) * distance + originPoint;
        return endPoint;
    }

    private void SetLine(Vector3 destination)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, destination);
        grabPoint.position = destination;
    }   
    
    private void ChangePositionCount(int lines){
        lineRenderer.positionCount = lines;
    }

    public void ClearPositionCount(){
        ChangePositionCount(0);
    }
}
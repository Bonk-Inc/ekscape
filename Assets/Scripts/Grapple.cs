using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    
    [SerializeField]
    private float maxLength = 1;

    [SerializeField]
    private float throwTime = 0.5f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            StartCoroutine(SendHook());
        }
    }

    private IEnumerator SendHook(){
        Vector3 finalEndPoint = CalculateEndPoint(transform.position, Input.mousePosition, maxLength);
        Vector3 originalPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentEndPoint = transform.position;
        float originTime = Time.time;
        float timeDuration = 0;

        while(Input.GetMouseButton(0)){
            while(timeDuration <= throwTime){
                timeDuration += Time.deltaTime;
                float hookLength = maxLength / throwTime * timeDuration;
                currentEndPoint = CalculateEndPoint(transform.position, originalPoint, hookLength);
                ChangeLine(currentEndPoint);
                yield return null;    
            }
            ChangeLine(currentEndPoint);
            yield return null;
        }
    }

    private Vector3 CalculateEndPoint(Vector3 originPoint, Vector3 wantedPosition, float distance){
        Vector3 endPoint = Vector3.Normalize(wantedPosition - originPoint) * distance + originPoint;
        return endPoint;

    }

    private void ChangeLine(Vector3 destination)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, destination);
    }   
    private void ChangeLine(Vector2 destination)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, destination);
    }
}

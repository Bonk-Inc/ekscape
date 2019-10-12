using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private float maxLength = 1;

    [SerializeField]
    private LineRenderer lineRenderer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            //doe de roar!
        }
    }

    private void ChangeLine(Vector3 destination)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, destination);
    }
}

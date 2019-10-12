using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{

    [SerializeField]
    private float patrollSize = 2;

    [SerializeField]
    private float speed = 1;

    private Rigidbody2D rb;
    private float xOne, xTwo;
    private float currentGoal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        xOne = transform.position.x - patrollSize / 2;
        xTwo = transform.position.x + patrollSize / 2;

        currentGoal = xOne;
    }

    private void Update()
    {
        var dir = currentGoal - rb.transform.position.x;
        rb.transform.position += 
    }

    private void OnDrawGizmos()
    {
        var pointOne = transform.position;
        pointOne.x -= patrollSize / 2;

        var pointTwo = transform.position;
        pointTwo.x += patrollSize / 2;
        Gizmos.DrawLine(pointOne, pointTwo);      
    }

}

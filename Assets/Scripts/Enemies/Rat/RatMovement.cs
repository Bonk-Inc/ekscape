using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {

    [SerializeField]
    private float patrollSize = 2;

    [SerializeField]
    private float speed = 1;

    private Rigidbody2D rb;

    private float[] targets = new float[2];
    private int currentGoal;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        targets[0] = transform.position.x - patrollSize / 2;
        targets[1] = transform.position.x + patrollSize / 2;

        currentGoal = 0;
    }

    private void Update() {
        var diff = targets[currentGoal] - rb.transform.position.x;
        var dir = diff / Mathf.Abs(diff);
        rb.transform.Translate(dir * speed * Time.deltaTime, 0, 0);

        if (Mathf.Abs(diff) < 0.05)
            SetNextTarget();
    }

    private void SetNextTarget()
    {
        currentGoal++;
        currentGoal %= targets.Length;
    }

    private void OnDrawGizmos() {
        var pointOne = transform.position;
        pointOne.x -= patrollSize / 2;

        var pointTwo = transform.position;
        pointTwo.x += patrollSize / 2;
        Gizmos.DrawLine(pointOne, pointTwo);
    }

}
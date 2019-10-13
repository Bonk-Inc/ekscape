using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform lineTop;

    [SerializeField]
    private Transform[] targets;
    private int currentTarget = 0;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private float waitTime = 3;

    public void Awake()
    {
        StartCoroutine(BeASpooder());
    }

    public IEnumerator BeASpooder()
    {
        while (true)
        {
            SetNextTarget();
            yield return StartCoroutine(GoToTarget(targets[currentTarget]));
            yield return new WaitForSeconds(waitTime);
            
        }
    }

    private IEnumerator GoToTarget(Transform target)
    {
        while(Vector2.Distance(target.position, transform.position) > 0.06)
        {
            var newPosition = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);
            MoveTo(newPosition);
            yield return null;
        }
        MoveTo(target.position);
    }

    private void SetNextTarget()
    {
        currentTarget++;
        currentTarget %= targets.Length;
    }

    private void MoveTo(Vector3 localPosition)
    {
        rb.transform.position = localPosition;

        Vector3[] linePositions = new Vector3[]
        {
            lineTop.transform.position,
            localPosition
        };

        lineRenderer.SetPositions(linePositions);
    }




}

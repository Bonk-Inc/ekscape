using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionLerper : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float lerpSpeed;

    private Coroutine moveRoutine = null;

    public void MoveToTarget()
    {
        if (moveRoutine != null)
            return;

        moveRoutine = StartCoroutine(MoveToTargetRoutine());
    }
        
    public void StopMoving()
    {
        if (moveRoutine == null)
            return;

        StopCoroutine(moveRoutine);
        moveRoutine = null;
    }

    private IEnumerator MoveToTargetRoutine()
    {
        while ((transform.position - target.position).magnitude > 0.002f)
        {
            var desiredPosition = target.position;
            Vector3 newPosition = Vector2.Lerp(transform.position, desiredPosition, lerpSpeed * Time.fixedDeltaTime);
            newPosition.z = transform.position.z;
            transform.position = newPosition;
            yield return new WaitForFixedUpdate();
        }
    }

}

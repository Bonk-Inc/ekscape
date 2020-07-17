using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private SceneLevelHandler sceneLevelHandler;

    private Transform follow;

    [SerializeField]
    private float followSpeed;

    private void Awake()
    {
        sceneLevelHandler = FindObjectOfType<SceneLevelHandler>();
        sceneLevelHandler.OnPlayerSetup += SetUpFollow;
    }

    private void SetUpFollow(Transform target)
    {
        this.follow = target;
    }

    void FixedUpdate()
    {
        var Position2D = Vector2.Lerp(this.transform.position, follow.transform.position, followSpeed * Time.deltaTime);
        transform.position = new Vector3(Position2D.x, Position2D.y, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] float zAxis = -10;

    void LateUpdate()
    {
        transform.position = new Vector3(follow.position.x,follow.position.y,zAxis);
    }
}

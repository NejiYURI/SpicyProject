using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform followTarget;

    public Vector3 Offset;

    public float MovementDelay;

    private void Start()
    {
        if (followTarget != null)
        {
            this.transform.position = followTarget.position + Offset;
        }
    }
    private void FixedUpdate()
    {
        if (followTarget != null)
        {
            Vector3 deltaMove = Vector3.Lerp(this.transform.position, followTarget.position+ Offset, MovementDelay);
            this.transform.position = deltaMove;
        }
    }
}

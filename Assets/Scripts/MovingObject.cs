using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    private float moveDir = 1.0f;
    [SerializeField] float xRange = 6.0f;
    [SerializeField] float speed = 3f;

    public virtual void MoveLinear()
    {
        if (transform.position.x < -xRange)
        {
            moveDir = 1f;
        }

        if (transform.position.x > xRange)
        {
            moveDir = -1f;
        }

        transform.Translate(Vector3.forward * (moveDir * Time.deltaTime * speed));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    protected GameManager gameManager;
    private float moveDir = 1.0f;
    [SerializeField] float xRange = 6.0f;
    public float speed = 1.0f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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

        // Translate relative to World
        transform.Translate(Vector3.right * (moveDir * Time.deltaTime * speed), Space.World);
    }
}

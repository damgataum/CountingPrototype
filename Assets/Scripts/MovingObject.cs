using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    protected GameManager gameManager;
    private float moveDir = 1.0f;
    private float xRange = 6.0f;
    private float m_Speed = 1.0f;
    public float Speed {
        get {return m_Speed;} // getter returns backing field
        set {m_Speed = value;} // setter uses backing field
    }

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
        transform.Translate(Vector3.right * (moveDir * Time.deltaTime * m_Speed), Space.World);
    }
}

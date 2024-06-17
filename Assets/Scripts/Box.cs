using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float xRange = 6.0f;
    private float moveDir = 1.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {

            if (transform.position.x < -xRange)
            {
                moveDir = 1f;
            }

            if (transform.position.x > xRange)
            {
                moveDir = -1f;
            }

            transform.Translate(Vector3.forward * moveDir * Time.deltaTime * speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(1);
        }
    }
}

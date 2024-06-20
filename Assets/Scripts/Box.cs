using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MovingObject
{
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
            MoveLinear();     
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

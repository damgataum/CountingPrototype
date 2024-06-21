using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MovingObject
{
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

    public override void MoveLinear()
    {   
        Speed = 3f;
        base.MoveLinear();
    }
}

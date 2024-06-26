using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MovingObject // INHERITANCE
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

    // ABSTRACTION
    public override void MoveLinear() // POLYMORPHISM
    {   
        Speed = 3f;
        base.MoveLinear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObject // INHERITANCE
{
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MoveLinear();     
        }
    }

    // ABSTRACTION
    public override void MoveLinear() // POLYMORPHISM
    {   
        Speed = 2f;
        base.MoveLinear();
    }
}

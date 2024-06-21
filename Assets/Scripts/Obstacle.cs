using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObject
{
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MoveLinear();     
        }
    }

    public override void MoveLinear()
    {   
        speed = 2f;
        base.MoveLinear();
    }
}

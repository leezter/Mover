using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditorInternal;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public enum MoveType 
    {
        Walk,
        Fly
    }
    public MoveType moveType;
    public float moveSpeed = 3;

    private GameObject player;
    private Vector3 target = new Vector3(0, 0, 3.93f);
    private bool flyTarget = false;

    private void Walk()
    {
        if (moveType == MoveType.Walk)
        {
            player = this.gameObject;
            this.transform.position = Vector3.MoveTowards
                (this.transform.position, target, Time.deltaTime * moveSpeed);
        }    
    }

    private void Fly()
    {
        if (moveType == MoveType.Fly)
        {
            player = this.gameObject;      
            Vector3 flyDistance = new Vector3(0, 2, 3.93f);
            if (!flyTarget)
            {
                this.transform.position = Vector3.MoveTowards
                    (this.transform.position, flyDistance, Time.deltaTime * moveSpeed);

                if (this.transform.position == flyDistance)
                {
                    flyTarget = true;
                }
            }
            else if (flyTarget)
            {
                this.transform.position = Vector3.MoveTowards
                    (this.transform.position, target, Time.deltaTime * moveSpeed);
            }
        }
    }
    public void Update()
    {
        Walk();
        Fly();
    }
}
//A new type of movement such as teleport could simply be added as a new method 'Teleport()' 
//which would make use of the 'target' variable to reach the required destination. A new 
// value should be added to the enum type 'MoveType' to make it accessible as an optional
//move type.
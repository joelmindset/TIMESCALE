using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVER : MonoBehaviour
{
    public float movementSpeed = 1f;
    public bool flipped = true;
    
    void Update()
    {
        if (flipped)
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        else if (!flipped)
        {
            transform.position -= Vector3.right * Time.deltaTime * movementSpeed;
        }       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!flipped)
        {
            flipped = true;
            
        } else 
        {
            flipped = false;
        }          
    }
}

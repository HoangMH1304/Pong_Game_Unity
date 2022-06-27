using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    void FixedUpdate()
    {
        xDirection = Input.GetAxisRaw("Vertical");   
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        // Debug.Log(xDirection);
        // Debug.Log(transform.position.y);
        transform.position = transform.position + new Vector3(0, moveStep, 0); 
    }
}

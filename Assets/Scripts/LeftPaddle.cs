using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    void FixedUpdate()
    {
        xDirection = Input.GetAxisRaw("Vertical");
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        transform.position += new Vector3(0, moveStep, 0); 
    }
}

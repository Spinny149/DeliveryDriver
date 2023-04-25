using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;


    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag =="Objects")
        {
            moveSpeed = slowSpeed;
            Debug.Log(steerSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
     {
        moveSpeed = boostSpeed;
        Debug.Log(steerSpeed);
    }
}

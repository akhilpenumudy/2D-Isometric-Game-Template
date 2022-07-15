using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector2 PlayerInput;
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] public static float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {

        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
       rb.velocity = new Vector2(moveH, moveV);
        Debug.Log(rb.velocity); 

        Vector2 direction = new Vector2(moveH, moveV).normalized;

     FindObjectOfType<PlayerAnimation>().SetDirection(direction);

        

    }



    



}

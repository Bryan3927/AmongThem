using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;

    Vector2 movement;

    public int choice = 1;
    public bool h_isAxisInUse = false;

    public int counter = 1;
    public static Vector2 leftP = new Vector2( -6,-2);
    public static Vector2 centerP = new Vector2( 0,-2);
    public static Vector2 rightP = new Vector2( 6,-2);

    Vector2[] positions = new Vector2[]{leftP, centerP, rightP};

    //start at 0 use counter 
    //if left key counter -1 or 0 and so on
    // target = function (counter)
    // position += (target - position) * 0.1

    // Update is called once per frame
    void Update()
    {
        //Input
        if (choice==1){
            movement.x=Input.GetAxisRaw("Horizontal");
            movement.y=Input.GetAxisRaw("Vertical");
        }

        else{
            if( Input.GetAxisRaw("Horizontal") != 0){
                if(h_isAxisInUse == false){
                // Call your event function here.
                Move();
                h_isAxisInUse = true;
                }
            }
            if( Input.GetAxisRaw("Horizontal") == 0){
                h_isAxisInUse = false;
            }    

        }
        
    }

    private void Move(){
        if (Input.GetAxisRaw("Horizontal")==0){
            ;
        } else if (Input.GetAxisRaw("Horizontal")<0) {
            counter = Mathf.Max(0, counter-1);
        } else if (Input.GetAxisRaw("Horizontal")>0) {
            counter = Mathf.Min(2, counter+1);
        }    
    }

    void FixedUpdate()
    {
        //Movement
        if (choice==1){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else{
            rb.position += (positions[counter] - rb.position) * 0.1f;
        }
        
    }
}

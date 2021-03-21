using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int choice = 1;
    public bool bow = false;
    public int health = 10;
    int[] identity = new int[2];

    //movement fields
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public int counter = 1;
    public static Vector2 leftP = new Vector2( -6,-2);
    public static Vector2 centerP = new Vector2( 0,-2);
    public static Vector2 rightP = new Vector2( 6,-2);
    Vector2[] positions = new Vector2[]{leftP, centerP, rightP};

    void Start(){
        //populate identity
        identity[0] = Random.Range(1,5); //team
        identity[1] = Random.Range(1, 11); //rank
    }

    void Update()
    {
        //Input
        if (choice==1){
            movement.x=Input.GetAxisRaw("Horizontal");
            movement.y=Input.GetAxisRaw("Vertical");
        }

        else{

            if (Input.anyKeyDown){
                if (choice==2){
                    Move1();
                }
                else{
                    Move2();
                }
                Bow();
            }
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

    private void Move1(){
        if (Input.GetAxisRaw("Horizontal")<0) {
            counter = Mathf.Max(0, counter-1);
        } else if (Input.GetAxisRaw("Horizontal")>0) {
            counter = Mathf.Min(2, counter+1);
        }    
        else{
            ;
        }
    }

    private void Move2(){
        if (Input.GetAxisRaw("Horizontal")<0) {
            counter = 0;
        } else if (Input.GetAxisRaw("Vertical")<0){
            counter = 1;
        } else if (Input.GetAxisRaw("Horizontal")>0) {
            counter = 2;
        }
        else {
            ;
        }
    }

    private void Bow(){
        if (Input.GetAxisRaw("Bow")>0){
            bow=!bow;
            Debug.Log(identity[0]);
            Debug.Log(identity[1]);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "NPC 1"){
            int[] npc_info = new int[]{2, 10};
            Check(npc_info);
        }  
    }

    private void Check(int[] npc){
        //see if player bowed correctly
        if (npc[0]==identity[0]){ //same team
            if (identity[1]+5<=npc[1]){ //player is higher rank
                if (bow) {health--;}
            }
            else{
                if (!bow) {health--;} //player is lower rank
            }
        }
        else{
            if (identity[1]<=npc[1]){ //player is higher rank
                if (bow) {health--;}
            }
            else {
                if (!bow) {health--;}
            }
        }
    }
}

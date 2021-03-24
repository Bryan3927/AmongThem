using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int choice = 1;
    public bool bow = false;
    public int health = 10;
    int[] identity = new int[2];
    public bool collide = false;

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
        Debug.Log(identity[0]);
        Debug.Log(identity[1]);
    }

    void Update()
    {
        //Input

        //movement
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
            }
        }

        if (Input.anyKeyDown){
            Bow();
        }
    }

    void FixedUpdate()
    {
        if (!collide){
            //Movement
            if (choice==1){
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }
            else{
                rb.position += (positions[counter] - rb.position) * 0.1f;
            }
        }

        //if (collide and getCurrentime() - time_collision > 1 sec)
            
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
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "NPC 1(Clone)"){
            collide = true;
            NPC script = col.gameObject.GetComponent<NPC>();
            int[] npc_info = new int[] { script.team, script.rank };
            script.Reaction(Check(npc_info)); // adjust health, trigger encounter animations
            collide = false; //TODO
        }  
    }

    private bool Check(int[] npc){
        //see if player bowed correctly
        if (npc[0]==identity[0]){ //same team
            if (identity[1]+5<=npc[1]){ //player is higher rank
                if (bow) {
                    health--;
                    return false;
                }
            }
            else{
                if (!bow) { //player is lower rank
                    health--;
                    return false;
                } 
            }
        }
        else{
            if (identity[1]<=npc[1]){ //player is higher rank
                if (bow) {
                    health--;
                    return false;
                }
            }
            else {
                if (!bow) { //player is lower rank
                    health--;
                    return false;
                }
            }
        }

        return true;
    }
}

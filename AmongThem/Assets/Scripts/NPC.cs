using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    NPCDeployer script;
    private int team;
    private int rank;
    public Animator animator;
    private bool shift = false;
    private Vector2 shiftLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, - speed );
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject deployer = GameObject.Find("Deployer");
        script = deployer.GetComponent<NPCDeployer>();
        shiftLeft = new Vector2(this.transform.position.x - 2, rb.position.y);
    }

    public void InitNPC(int team, int rank)
    {
        // Initializes the NPC's team and rank
        this.team = team; 
        this.rank = rank;
        animator.SetInteger("Team", team-1);
        textHandler text = transform.GetChild(0).gameObject.GetComponent<textHandler>();
        text.InitValue(rank);
    }

    public void Reaction(bool respect, bool crash)
    {
        // respect is true when this NPC should bow out of the way of the player
        // crash is true when the player 

        // trigger NPC animations
        // speed = 0;
        // rb.velocity = new Vector2(0, -speed);
        // after animation done, reset speed
        if (respect)
        {
            animator.SetBool("Respecting", true);
            shift = true;
        }

        if (crash)
        {
            animator.SetBool("Disrespecting", true);
        }
    }

    public int GetTeam()
    {
        return team;
    }

    public int GetRank()
    {
        return rank;
    }

    // Update is called once per frame
    void Update()
    {
        if (shift)
        {
            shiftLeft = new Vector2(shiftLeft.x, rb.position.y);
            Vector2 destination = (shiftLeft - rb.position) * 0.1f;
            rb.position += destination;
        }


        if (transform.position.y < -screenBounds.y * 2)
        {
            Debug.Log("Team returning");
            Debug.Log(team);
            script.returnPerson(new List<int>() { team, rank });
            Destroy(this.gameObject);
        }
    }
}

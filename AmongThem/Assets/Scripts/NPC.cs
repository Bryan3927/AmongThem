using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    NPCDeployer script;
    public int team;
    public int rank;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, - speed );
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject deployer = GameObject.Find("Deployer");
        script = deployer.GetComponent<NPCDeployer>();
    }

    public void InitNPC(int team, int rank)
    {
        // Initializes the NPC's team and rank
        this.team = team; 
        this.rank = rank;
        transform.GetChild(0).gameObject.GetComponent<textHandler>().InitValue(rank);
    }

    public void Reaction(bool proper)
    {
        // trigger NPC animations
        // speed = 0;
        // rb.velocity = new Vector2(0, -speed);
        // after animation done, reset speed
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -screenBounds.y * 2)
        {
            script.returnPerson(new List<int>() { team, rank });
            Destroy(this.gameObject);
        }
    }
}

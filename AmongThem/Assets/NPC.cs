using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private string NPCValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, - speed );
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void InitNPC(string value)
    {
        // txtNPCValue = this.GetComponent<Text>(); // get the text component of the cell
        NPCValue = value; // set the value
        // txtNPCValue.text = NPCValue.ToString(); // update the GUI
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }
}

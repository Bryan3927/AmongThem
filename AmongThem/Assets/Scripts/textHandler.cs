using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textHandler : MonoBehaviour
{
    private TextMesh txt;
    // Start is called before the first frame update
    void Start()
    {
        // txt = this.GetComponent<TextMesh>();
        // txt.text = "filler";
    }

    public void InitValue(int value)
    {
        // Initializes displayed rank
        txt = this.GetComponent<TextMesh>();
        txt.text = value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textHandler : MonoBehaviour
{
    public string NPCValue = "";
    private TextMesh txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<TextMesh>();
    }

    public void InitValue(string value)
    {
        NPCValue = value;
        txt.text = NPCValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

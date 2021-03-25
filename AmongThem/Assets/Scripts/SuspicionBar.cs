using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

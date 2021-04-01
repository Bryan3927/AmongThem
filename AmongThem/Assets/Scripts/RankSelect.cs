using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSelect : MonoBehaviour
{
    public GameObject victoryPrefab;
    public GameObject lossPrefab;
    
    private GameObject[] choices;
    private int index=0;

    private bool start = false;
    private bool waited = false;

    private void Start()
    {   
        choices = new GameObject[transform.childCount];

        //populate choices
        for (int i=0; i<transform.childCount; i++){
            choices[i] = transform.GetChild(i).gameObject;
        }

        //toggle off renderer
        foreach (GameObject go in choices){
            go.SetActive(false);
        }

    }

    private void Update()
    {
        if (start){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                ToggleLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)){
                ToggleRight();
            }
            else if(Input.GetKeyDown(KeyCode.Return)){
                if (waited){
                    Confirm();
                }
                waited=true;
            }
            else{
                ;
            }
        }

    }

    public void ToggleLeft()
    {
        //toogle off current model
        choices[index].SetActive(false);

        index--;
        if(index<0){
            index= choices.Length-1;
        }

        //toggle on current model
        choices[index].SetActive(true);

    }

    public void ToggleRight()
    {
        //toogle off current model
        choices[index].SetActive(false);

        index++;
        if(index==choices.Length){
            index=0;
        }

        //toggle on current model
        choices[index].SetActive(true);

    }

    public void Confirm(){
        int[] id = PlayerStats.Identity;
        if (id[0]==PlayerStats.Team && id[1]==index+1) //this is the rank script so index is rank
        {
            GameObject w = Instantiate(victoryPrefab) as GameObject;
        }  
        else 
        {
            GameObject l = Instantiate(lossPrefab) as GameObject;
        }
    }


    public void turnOn(){
        start=true;
        choices[0].SetActive(true);
    }

}

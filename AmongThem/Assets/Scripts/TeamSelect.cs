using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelect : MonoBehaviour
{
    private GameObject[] choices;
    private int index=0;

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

        //toggle on first choice
        if(choices[0]){
            choices[0].SetActive(true);
        }


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ToggleLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            ToggleRight();
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            Confirm();
        }
        else{
            ;
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
        Debug.Log("Confirm");
        GameObject.Find("Rank Selection").GetComponent<RankSelect>().turnOn();
        PlayerStats.Team=index+1;
        transform.gameObject.SetActive(false);
    }

     

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right shift")){ //guess button
            LoadNextLevel();
        }
        
        else if (Input.GetKeyDown("left shift")){ //reset button
            RestartGame();
        }
        
        //add reset button for loading first scene

        //add button to trigger pokemon cut sequence on every counter (this is unique to other build)
    }


    public void LoadNextLevel(){
    	//GameObject image = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
    	//image.GetComponent<CanvasGroup>().alpha = 1f; 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));

    }

    public void PlayGame(){
    	GameObject background = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject; 
    	background.SetActive(false); 

    	LoadNextLevel(); 

    }

    public void LoadCredit(){
    	GameObject creditScene = transform.GetChild(0).gameObject.transform.GetChild(5).gameObject; 
    	GameObject backButton = transform.GetChild(0).gameObject.transform.GetChild(7).gameObject; 
    	creditScene.SetActive(true); 
    	backButton.SetActive(true); 
    }

    public void LoadHowTo(){
    	GameObject howToScene = transform.GetChild(0).gameObject.transform.GetChild(6).gameObject; 
    	GameObject backButton = transform.GetChild(0).gameObject.transform.GetChild(7).gameObject; 
    	howToScene.SetActive(true); 
    	backButton.SetActive(true); 
    }

    public void backTitle(){
    	GameObject backButton = transform.GetChild(0).gameObject.transform.GetChild(7).gameObject; 
    	GameObject creditScene = transform.GetChild(0).gameObject.transform.GetChild(5).gameObject; 
    	GameObject howToScene = transform.GetChild(0).gameObject.transform.GetChild(6).gameObject; 
    	creditScene.SetActive(false); 
    	howToScene.SetActive(false); 
    	backButton.SetActive(false); 
    }

    public void RestartGame(){
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}

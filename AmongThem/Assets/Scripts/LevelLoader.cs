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

    void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    void RestartGame(){
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }


    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReStartGame(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}

/*----------------------------------------------------------------------------
Source file name: Menu.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 27, 2016
Program description: This program is for the screen of pause UI
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - Fixed the text
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //Declare public variables
    public GameObject PauseUI;

    //Declare private variables
    private bool _paused;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            this._paused = !this._paused;
        }

        if(this._paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!this._paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 0.5f;
        }
    }

    public void Resume()
    {
        this._paused = false;
    }

    public void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);

        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void gameStart()
    {
        
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

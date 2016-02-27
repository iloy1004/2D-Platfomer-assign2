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

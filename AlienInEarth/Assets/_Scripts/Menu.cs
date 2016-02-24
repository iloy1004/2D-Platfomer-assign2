using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    //Declare public variables
    public GameObject PauseUI;

    //Declare private variables
    private bool _paused = false;

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
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

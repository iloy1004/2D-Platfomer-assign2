using UnityEngine;
using System.Collections;

public class HomeMenu : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gameStart()
    {
        Application.LoadLevel(1);
    }
}

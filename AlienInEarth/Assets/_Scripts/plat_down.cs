/*----------------------------------------------------------------------------
Source file name: plat_down.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 28, 2016
Program description: Don't use this code. This code is for falling of platforms after touching between player and ground.
                     But it made the game too difficult.
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - Complete the code
----------------------------------------------------------------------------*/


using UnityEngine;
using System.Collections;

public class plat_down : MonoBehaviour {

    public int verticalMin = 120;
    public int verticalMax = 700;

    public int horizontalMin = -229;
    public int horizontalMax = 314;

    private Transform yaxis;

    // Use this for initialization
    void Start () {

        this.yaxis = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

        this.yaxis.Translate(new Vector2(0.0f, -0.5f) );

        int screenOut = Random.Range(-489, -800);

        if (this.yaxis.position.y < screenOut)
        {

            float randomX = Random.Range(horizontalMin, horizontalMax);
            float randomY = Random.Range(verticalMin, verticalMax);

            this.yaxis.position = new Vector3(randomX, randomY, 0);

            Debug.Log("x: " + Random.Range(horizontalMin, horizontalMax));
            Debug.Log("y: " + Random.Range(verticalMin, verticalMax));
        }
    }
}

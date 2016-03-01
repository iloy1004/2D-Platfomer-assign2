/*----------------------------------------------------------------------------
Source file name: Spikes.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 27, 2016
Program description: This makes the damage for player and player's reaction.
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  0.2 - added the player's reaction
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    //Declare private variables
    public PlayerController _Player;


    // Use this for initialization
    void Start () {
        //this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            this._Player.Damage(1);
            StartCoroutine(this._Player.Knockback(0.02f, 50f, this._Player.transform.position, -50f));
            
            //gameObject.GetComponent<Animation>().Play("hurt");
        }
    }


}

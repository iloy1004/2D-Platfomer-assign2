using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    //Declare private variables
    private PlayerController _Player;


    // Use this for initialization
    void Start () {
        this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            this._Player.Damage(1);
            StartCoroutine(this._Player.Knockback(0.02f, 50f, this._Player.transform.position, -50f));
        }
    }


}

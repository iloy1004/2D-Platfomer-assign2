using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    //Declare private variables
    private AlienController _Player;


    // Use this for initialization
    void Start () {
        this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<AlienController>();
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            this._Player.Damage(1);
            StartCoroutine(this._Player.Knockback(0.02f, 100f, this._Player.transform.position));
        }
    }
}

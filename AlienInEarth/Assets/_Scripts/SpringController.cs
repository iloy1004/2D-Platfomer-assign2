/*----------------------------------------------------------------------------
Source file name: SpringController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 27, 2016
Program description: Make the high jumping when player touch the spring
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - Fixed the movement
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class SpringController : MonoBehaviour {

    //Declare public variables
    public float BounceForce = 5f;

    public PlayerController _Player;
    private Animator _animator;
    private Transform _transform;

    // Use this for initialization
    void Start () {
        //this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        //set private instance variables
        this._animator = gameObject.GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Touch the spring");
        this._animator.SetBool("isHit", true);

        if (col.CompareTag("Player"))
        {
            Debug.Log(this._transform.eulerAngles.z);

            //if spring is facing left, player will jump in the left way
            if (this._transform.eulerAngles.z < 300)
            {
                Debug.Log("Facing Left");
                
                StartCoroutine(this._Player.Knockback(0.02f, BounceForce, this._Player.transform.position, -600));
            }
            //otherwise, player will jump in the right way
            else
            {
                Debug.Log("Facing Right");
                StartCoroutine(this._Player.Knockback(0.02f, BounceForce, this._Player.transform.position, -400));
            }

            //this._animator.SetBool("isHit", false);
        }
    }

}

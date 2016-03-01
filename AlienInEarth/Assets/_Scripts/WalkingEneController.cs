/*----------------------------------------------------------------------------
Source file name: CoinController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 28, 2016
Program description: This is for the movement of enemy
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - set up the enemy's movement and duration to turn around.
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class WalkingEneController : MonoBehaviour {



    //Declare pubic variables
    public LayerMask enemyMask;
    public float speed = 10f;
    public float minDuration;
    public float maxDuration;

    //Declare private variables
    private bool _facingRight;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private float _myWidth;
    private float _myHeight;
    private float _timeLeft;
    private float _turnDuration;

    // Use this for initialization
    public void Start () {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        //this._transform = this.transform;
        this._transform = gameObject.GetComponent<Transform>();
        SpriteRenderer mySprite = gameObject.GetComponent<SpriteRenderer>();
        this._myWidth = mySprite.bounds.extents.x;
        this._myHeight = mySprite.bounds.extents.y;

        this._turnDuration = Random.Range(this.minDuration, this.maxDuration);

        this._timeLeft = this._turnDuration;
	}
	
	// Update is called once per frame
	void Update () {

        this._timeLeft -= 1;

        //Debug.Log(this._timeLeft);

        if(this._timeLeft <= 0.0f)
        {
                Vector3 currRotation = this._transform.eulerAngles;
                currRotation.y += 180;
                this._transform.eulerAngles = currRotation;

                this._timeLeft = this._turnDuration;
        }

        //Check to see if there's ground in front of us before moving forward
        /*
        Vector2 lineCastPos = this._transform.position - this._transform.right * _myWidth;
        bool _isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);

        Debug.Log(_isGrounded);

        //if there's no ground, turn around
        /*
        if (!_isGrounded)
        {
            Vector3 currRotation = this._transform.eulerAngles;
            currRotation.y += 180;
            this._transform.eulerAngles = currRotation;
        }
        */
        Vector2 myVel = this._rigidbody2D.velocity;
        myVel.x = -this._transform.right.x * speed;
        this._rigidbody2D.velocity = myVel;
        /*

            //Always move forward
            Vector2 myVel = this._rigidbody2D.velocity;
            myVel.x = -this._transform.right.x * this.speed;
            this._rigidbody2D.velocity = new Vector2(-this._rigidbody2D.velocity.x * this.speed, 0);
            this._rigidbody2D.velocity = myVel;
            */
            

    }

}

using UnityEngine;
using System.Collections;

public class WalkingEneController : MonoBehaviour {



    //Declare pubic variables
    public LayerMask enemyMask;
    public float speed = 1f;

    //Declare private variables
    private bool _facingRight;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    private float _myWidth;
    private float _myHeight;

    // Use this for initialization
    public void Start () {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        //this._transform = this.transform;
        this._transform = gameObject.GetComponent<Transform>();
        SpriteRenderer mySprite = gameObject.GetComponent<SpriteRenderer>();
        this._myWidth = mySprite.bounds.extents.x;
        this._myHeight = mySprite.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {

        //Check to see if there's ground in front of us before moving forward
        Vector2 lineCastPos = this._transform.position - this._transform.right * _myWidth;
        bool _isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, 1 << LayerMask.NameToLayer("enemy"));
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);

        Debug.Log(_isGrounded);

        //if there's no ground, turn around
        if(!_isGrounded)
        {
            Vector3 currRotation = this._transform.eulerAngles;
            currRotation.y += 180;
            this._transform.eulerAngles = currRotation;
        }
        else
        {
            //Always move forward
            //Vector2 myVel = this._rigidbody2D.velocity;
            //myVel.x = -this._transform.right.x * this.speed;
            this._rigidbody2D.velocity = new Vector2(-this._rigidbody2D.velocity.x * this.speed, 0);
            //this._rigidbody2D.velocity = myVel;

        }
        
	}

}

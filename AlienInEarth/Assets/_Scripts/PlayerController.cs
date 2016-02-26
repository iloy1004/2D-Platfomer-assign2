using UnityEngine;
using System.Collections;

//Velocity range utility class
[System.Serializable]
public class VelocityRange
{
    //public instance variables
    public float minimum;
    public float maximum;

    // Constructor
    public VelocityRange(float minimum, float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}

public class PlayerController : MonoBehaviour {

    //Public variables
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    public Transform groundCheck;


    //states
    public int curHealth = 4;
    public int maxHealth = 4;

    // PRIVATE Instance variables
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2d;
    private bool _isGrounded;

    //Set audio variables
    private AudioSource[] _audioSources;
    private AudioSource _jumpSound;
    private AudioSource _coinSound;
    private AudioSource _hurtSound;
    private AudioSource _lazerSound;
   


    // Use this for initialization
    void Start()
    {
        //Initialize public instance variables
        this.velocityRange = new VelocityRange(300f, 10000f);
        

        //set private instance variables
        this._animator = gameObject.GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
        this._rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;

        this.curHealth = this.maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {

        this._isGrounded = Physics2D.Linecast(
                            this._transform.position, 
                            this.groundCheck.position, 
                            1 << LayerMask.NameToLayer("Ground"));
        
        float forceX = 0f;
        float forceY = 0f;

        //get absolute value of velocity for game object
        float absVelX = Mathf.Abs(this._rigidBody2d.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2d.velocity.y);

        //Debug.Log(this._isGrounded);

        if (this._isGrounded)
        {
            //get a number between -1 to 1 for both Horizontal and Vertical Axes
            this._move = Input.GetAxis("Horizontal");
            this._jump = Input.GetAxis("Vertical");

            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    if(absVelX < this.velocityRange.maximum)
                    {
                        forceX = this.moveForce;
                    }
                    this._facingRight = true;
                    this._flip();

                    //move force
                }
                if (this._move < 0)
                {
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = -this.moveForce;
                    }

                    this._facingRight = false;
                    this._flip();

                    //move force
                }
            
                this._animator.SetInteger("Anim_state", 1);
            }
            else
            {
                this._animator.SetInteger("Anim_state", 0);
            }

            if (this._jump > 0)
            {
                //jump force
                if (absVelY < this.velocityRange.maximum)
                {
                    forceY = this.jumpForce;
                }
            }
        }
        else
        {
            //call the jump animation
            this._animator.SetInteger("Anim_state", 2);
        }

        //Debug.Log(forceX);
        //Apply forces to the player
        this._rigidBody2d.AddForce(new Vector2(forceX, forceY));

        if(this.curHealth > this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }

        if(this.curHealth <= 0)
        {
            Die();
        }
    }

    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }

    void Die()
    {
        //Restart the game
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        this.curHealth -= dmg;
        Debug.Log(this.curHealth);
        gameObject.GetComponent<Animation>().Play("knockback");
    }

    //When player hit the spikes, make the motion
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;
            this._rigidBody2d.AddForce(new Vector3(knockbackDir.x * -50, knockbackDir.y * knockPwr, transform.position.z));
        }

        yield return 0;
    }


}

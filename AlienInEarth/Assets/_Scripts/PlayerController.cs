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


    //Health states and scores
    public int curHealth = 4;
    public int maxHealth = 4;
    public int score = 0;
    public bool canDoubleJump;
    //public Animation hurtAnim;


    //Game over UI
    public GameObject GameoverUI;

    // PRIVATE Instance variables
    private Animator _animator;
    private float _move;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2d;
    private bool _isGrounded;

    //Set audio variables
    private AudioSource[] _audioSources;
    private AudioSource _jumpSound;
    private AudioSource _coinSound;
    private AudioSource _powerUpSound;
    private AudioSource _deadSound;
    private AudioSource _hurtSound;
    private AudioSource _gameover;
    private AudioSource _backSound;



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
        this._facingRight = true;

        this.curHealth = this.maxHealth;

        // Setup AudioSources
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._jumpSound = this._audioSources[0];
        this._powerUpSound = this._audioSources[1];
        this._deadSound = this._audioSources[2];
        this._hurtSound = this._audioSources[3];
        this._coinSound = this._audioSources[4];
        this._gameover = this._audioSources[5];
        this._backSound = this._audioSources[6];

        this.GameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        this._isGrounded = Physics2D.Linecast(
                            this._transform.position, 
                            this.groundCheck.position, 
                            1 << LayerMask.NameToLayer("Ground"));

        //get absolute value of velocity for game object
        float VelX = this._rigidBody2d.velocity.x;
        float VelY = this._rigidBody2d.velocity.y;

        this._animator.SetBool("isGrounded", this._isGrounded);
        this._animator.SetFloat("Speed", Mathf.Abs(this._rigidBody2d.velocity.x));


        this._move = Input.GetAxis("Horizontal");
   
        //Move the player
        this._rigidBody2d.AddForce((Vector2.right * this.moveForce) * this._move);

        if (this._move < -0.1f)
        {

            this._facingRight = false;
            this._flip();
        }
        else if(this._move > 0.1f)
        {
            //this._rigidBody2d.AddForce(Vector2.right * this.moveForce * this._move);
            this._facingRight = true;
            this._flip();
        }
        

        if (VelX > this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this.velocityRange.maximum, this._rigidBody2d.velocity.y);
        }
        if (VelX < -this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(-this.velocityRange.maximum, this._rigidBody2d.velocity.y);
        }

        if (VelY > this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, this.velocityRange.maximum);
        }
        if (VelY < -this.velocityRange.maximum)
        {
            this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, -this.velocityRange.maximum);
        }

        //Jump 
        if (Input.GetButtonDown("Jump"))
        {


            if(this._isGrounded)
            {
                this._rigidBody2d.AddForce(Vector2.up * this.jumpForce);
                this.canDoubleJump = true;
            }
            else
            {
                if(this.canDoubleJump)
                {
                    this.canDoubleJump = false;
                    this._rigidBody2d.velocity = new Vector2(this._rigidBody2d.velocity.x, 0);
                    this._rigidBody2d.AddForce(Vector2.up * this.jumpForce / 1.95f);

                }
            }
            this._jumpSound.Play();


        }

        //this._checkBounds();

        if (this.curHealth > this.maxHealth)
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

    private void _checkBounds()
    {
        if (this._transform.position.y > 2300f)
        {
            this._transform.position = new Vector3(this._transform.position.x, 2300f, 0);
        }
        if (this._transform.position.x < -1200.9f)
        {
            this._transform.position = new Vector3(-146.7f, this._transform.position.y, 0);
        }
        if (this._transform.position.x > 1445.2f)
        {
            this._transform.position = new Vector3(1445.2f, this._transform.position.y, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Death"))
        {
            this._deadSound.Play();       
            this._transform.position = new Vector3(-133.9f, -157.4f, 0);
            this.curHealth -= 1;
        }

        if (col.gameObject.CompareTag("goldCoins"))
        {
            Debug.Log("Touch the gold coin");
            this._coinSound.Play();
            Destroy(col.gameObject);
            this.score += 200;
        }

        if (col.gameObject.CompareTag("bronzeCoins"))
        {
            this._coinSound.Play();
            Destroy(col.gameObject);
            this.score += 100;
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            this.Damage(1);
            StartCoroutine(this.Knockback(0.02f, 100f, this._transform.position, -50f));
        }
    }

    void Die()
    {
        this._backSound.Stop();
        this._gameover.Play();
        this.GameoverUI.SetActive(true);
    }

    public void Damage(int dmg)
    {
        this.curHealth -= dmg;
        this._hurtSound.Play();
        //gameObject.GetComponent<Animation>().Play("hurt");
    }

    //When player hit the spikes, make the motion
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir, float knockFacing)
    {
        float timer = 0;

        while(knockDur > timer)
        {

            timer += Time.deltaTime;
            this._rigidBody2d.AddForce(new Vector3(knockbackDir.x * knockFacing, Mathf.Abs(knockbackDir.y) * knockPwr, transform.position.z));
        }

        yield return 0;
    }


}

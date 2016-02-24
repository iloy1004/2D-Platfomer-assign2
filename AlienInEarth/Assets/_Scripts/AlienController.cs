/*----------------------------------------------------------------------------
Source file name: AlienController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 05, 2016
Program description: alien is a player in this game, and this script is for controlling bunny. Here is controlling of movement, colision.
Revision history: 0.0 - Created document, and made basic methods, Start and Update()
                  0.1 - Added reset method
                  1.0 - Added Trigger Event for destruction
                  1.1 - Added animation of explosion
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;



public class AlienController : MonoBehaviour {

    //PRIVATE INSTANCE VARIABLES

    private float _move;
    private float _jump;
    private bool _facingRight;

    //PRIVATE VARIABLES
    private Transform _transform;
    private Rigidbody2D _myBody;
    private float _hInput;
    private Vector3 _artScaleCache;
    AnimationController myAnim;
    bool _isGrounded = false;

    //states
    public int curHealth;
    public int maxHealth = 4;

    //PUBLIC VARIABLES
    public float _speed = 10f;
    public float _jumpVelocity = 10f;
    public bool _canMoveInAir = true;
    public Transform TagGround;

    //public AnimatorControllerJS myAnim;

    // Use this for initialization
    void Start()
    {
        //Set default value for each variables
        this._myBody = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this.TagGround = GameObject.Find(this.name + "/tag_ground").transform;
        this.myAnim = AnimationController._instance;
        this.myAnim.UpdateIsGrounded(this._isGrounded);

        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;

        this.curHealth = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //this._isGrounded = Physics2D.Linecast(this._transform.position, this._tagGround.position, 1 << LayerMask.NameToLayer("Ground"));

//        this._isGrounded = Physics2D.Linecast(this._transform.position, this._tagGround.position, _payerMask);

        this._isGrounded = Physics2D.Linecast(
                            this._transform.position,
                            this.TagGround.position,
                            1 << LayerMask.NameToLayer("Ground"));


        Debug.Log(this._isGrounded);
        this.myAnim.UpdateIsGrounded(this._isGrounded);

        //if user play the game via NOT mobile phone, run this code
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
        this._hInput = Input.GetAxisRaw("Horizontal");
        this.myAnim.UpdateSpeed(this._hInput);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
#endif

        Move(this._hInput);


        if (this.curHealth > this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }

        if (this.curHealth <= 0)
        {
            Die();
        }

    }



    public void Jump()
    {
        if (this._isGrounded)
        {
            this._myBody.velocity += this._jumpVelocity * Vector2.up;
        }
    }

    public void Move(float horizontalInput)
    {
        if (!this._canMoveInAir && !this._isGrounded)
        {
            return;
        }

        Vector2 moveVel = this._myBody.velocity;
        moveVel.x = horizontalInput * this._speed;

        this._myBody.velocity = moveVel;
    }

    public void StartMoving(float horizonalInput)
    {
        this._hInput = horizonalInput;
        this.myAnim.UpdateSpeed(horizonalInput);
    }

    void Die()
    {
        //Restart the game
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        this.curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("knockback");
    }

    //When player hit the spikes, make the motion
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            this._myBody.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockPwr, transform.position.z));
        }

        yield return 0;
    }
}

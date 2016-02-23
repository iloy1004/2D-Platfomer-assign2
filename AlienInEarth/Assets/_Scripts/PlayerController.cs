﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // PRIVATE Instance variables
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        this._animator = gameObject.GetComponent<Animator>();
        this._move = 0f;
        this._jump = 0f;
        this._facingRight = true;
        this._transform = gameObject.GetComponent<Transform>();
        //set default
    }

    // Update is called once per frame
    void Update()
    {
        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");

        if (this._move != 0)
        {
            if (this._move > 0)
            {
                this._facingRight = true;
            }
            if (this._move < 0)
            {
                this._facingRight = false;
            }
            this._animator.SetInteger("Anim_state", 1);
        }
        else
        {
            this._animator.SetInteger("Anim_state", 0);
        }

        if (this._jump > 0)
        {
            //call the jump animation
            this._animator.SetInteger("Anim_state", 2);
        }

        this._flip();
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
}

using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {


        //PUBLIC VARIABLE
        public static AnimationController _instance;

        //PRIVATE VARIABLE
        private Transform _transform;
        private Animator _animator;
        private Vector3 _artScaleCache;

        //Constructor
        public AnimationController()
        {
            _instance = this;
        }

        // Use this for initialization
        void Start()
        {
            this._transform = gameObject.GetComponent<Transform>();
            this._animator = gameObject.GetComponent<Animator>();
            _instance = this;
            this._artScaleCache = this._transform.localScale;
        }


        void flip(float currentSpeed)
        {
            //going left and facing right                      or  going right and facing left
            if ((currentSpeed < 0 && this._artScaleCache.x > 0) || (currentSpeed > 0 && this._artScaleCache.x < 0))
            {
                //flip the player
                this._artScaleCache.x *= -1;
                this._transform.localScale = this._artScaleCache;

            }
        }

        public void UpdateSpeed(float currentSpeed)
        {
            this._animator.SetFloat("Speed", currentSpeed);
            this.flip(currentSpeed);
        }

        public void UpdateIsGrounded(bool isGrounded)
        {
            this._animator.SetBool("isGrounded", isGrounded);
        }
}

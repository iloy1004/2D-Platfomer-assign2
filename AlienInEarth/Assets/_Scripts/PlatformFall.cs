using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

    public float fallDelay;

    private Rigidbody2D _myBody;
    //private PlayerController _Player;

    // Use this for initialization
    void Start () {
        this._myBody = gameObject.GetComponent<Rigidbody2D>();
        //this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        
        this._myBody.isKinematic = false;
    }
}

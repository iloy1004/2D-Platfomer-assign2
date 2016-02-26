using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

    public float fallDelay;

    private Rigidbody2D _myBody;

	// Use this for initialization
	void Start () {
        this._myBody = gameObject.GetComponent<Rigidbody2D>();
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
        Debug.Log("Call the Fall");
        this._myBody.isKinematic = false;
    }
}

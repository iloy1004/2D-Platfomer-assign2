using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    
    //Declar public variables
    public float smoothTimeY;
    public float smoothTimeX;
    public GameObject player;
    //check if camera is bounded
    public bool isBounded;
    //minimum and maximum of camera position
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    //Declar private variables
    private Vector2 _velocity;

    // Use this for initialization
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref _velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref _velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(isBounded)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

    //Set the min and max of camera position
    public void setMaxCamPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }

    public void setMinCamPosition()
    {
        minCameraPos = gameObject.transform.position;
    }
}

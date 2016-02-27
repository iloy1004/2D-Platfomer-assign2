using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    //Set audio variables
    private AudioSource _audioSources;
    private AudioSource _coinSound;
    public PlayerController _Player;

    // Use this for initialization
    void Start () {
        this._audioSources = gameObject.GetComponent<AudioSource>();
        Debug.Log("Coin controller is started");
        this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Coin meets player");
                this._Player.score += 100;
           
            this._audioSources.Play();
            Destroy(gameObject);
        }
    }
}

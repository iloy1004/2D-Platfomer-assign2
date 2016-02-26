using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = 6.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;

    private Vector2 _originPosition;

	// Use this for initialization
	void Start () {
        this._originPosition = transform.position;
        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void Spawn()
    {
        for(int i=0; i< maxPlatforms; i++)
        {
            Vector2 randomPosition = this._originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            this._originPosition = randomPosition;
        }
    }
}

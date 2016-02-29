using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public int maxPlatforms = 5;
    private GameObject platform;
    private GameObject coin;
    private GameObject spring;
    private GameObject enemy;
    public int verticalMin = 120;
    public int verticalMax = 160;
    public int horizontalMin = -54;
    public int horizontalMax = 198;
    

    private Vector2 _originPosition;
    private int _plat_xtype = 1;
    private bool _isCoin;
    private bool _isSpring;
    private bool _isEnemy;
    private GameObject lastPlatform;

    // Use this for initialization
    void Start () {

        this._originPosition = transform.position;
        this._isCoin = false;
        this._isEnemy = false;
        this._isSpring = false;

        Spawn();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void ChoosePlat(int plat_xtype)
    {
        switch (plat_xtype)
        {
            case 1:
                platform = GameObject.Find("ground_snow");
                enemy = GameObject.Find("Slime_Green");
                this._isCoin = true;
                this._isSpring = false;
                this._isEnemy = true;
                break;
            case 2:
                platform = GameObject.Find("ground_grass");
                enemy = GameObject.Find("Slime");
                this._isCoin = false;
                this._isSpring = false;
                this._isEnemy = true;
                break;
            case 3:
                platform = GameObject.Find("ground_cake_broken");
                this._isCoin = false;
                this._isSpring = true;
                this._isEnemy = false;
                break;
            case 4:
                platform = GameObject.Find("ground_sand");
                enemy = GameObject.Find("Slime");
                this._isCoin = false;
                this._isSpring = false;
                this._isEnemy = true;
                break;
            case 5:
                platform = GameObject.Find("ground_stone_small_broken");
                this._isCoin = true;
                this._isSpring = false;
                this._isEnemy = false;
                break;
        }
    }

    void Spawn()
    {
        for(int i=0; i< maxPlatforms; i++)
        {
            //Vector2 randomPosition = this._originPosition + new Vector2(this._plat_x, 64);
            //Vector2 randomPosition = this._originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));

            Vector2 randomPosition = new Vector2(Random.Range(horizontalMin, horizontalMax), this._originPosition.y + Random.Range(verticalMin, verticalMax));
            
            //Choose the platform randomly
            this._plat_xtype = Random.Range(1, 5);
            this.ChoosePlat(this._plat_xtype);

            //Create platform
            Instantiate(platform, randomPosition, Quaternion.identity);

            this._originPosition = randomPosition;


            /*
            //Make coin
            if (this._isCoin)
            {
                Vector2 coinPosition_01 = new Vector2(this._originPosition.x, this._originPosition.y + 50);
                Vector2 coinPosition_02 = new Vector2(this._originPosition.x + 100, this._originPosition.y + 50);
                Vector2 coinPosition_03 = new Vector2(this._originPosition.x + 200, this._originPosition.y + 50);

                Instantiate(coin, coinPosition_01, Quaternion.identity);
                Instantiate(coin, coinPosition_02, Quaternion.identity);
                Instantiate(coin, coinPosition_03, Quaternion.identity);
            }

            //make spring
            if (this._isSpring)
            {
                Vector2 springPosition = new Vector2(this._originPosition.x, this._originPosition.y);
                Instantiate(spring, springPosition, Quaternion.identity);
            }

            //make enemy
            if (this._isEnemy)
            {
                Vector2 enemyPosition = new Vector2(this._originPosition.x, this._originPosition.y);

                Instantiate(enemy, enemyPosition, Quaternion.identity);
            }
            */
        }
    }
}

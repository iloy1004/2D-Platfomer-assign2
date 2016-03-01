/*----------------------------------------------------------------------------
Source file name: CoinController.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 29, 2016
Program description: Make the coins within the screen randomly.
Revision history: 0.0 - set up 
                  0.1 - made basic method
                  1.0 - Added the type of coins as gold or bronze
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    public int maxCoins = 100;
    public int verticalMin = 120;
    public int verticalMax = 2300;
    public int horizontalMin = -1200;
    public int horizontalMax = 1400;

    private GameObject coin;
    private Vector2 _originPosition;
    private int _coinType;

    // Use this for initialization
    void Start () {
        Spawn();   
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChooseCoin(int coinType)
    {
        switch (coinType)
        {
            case 1:
                coin = GameObject.Find("coin_bronze");
                break;
            case 2:
                coin = GameObject.Find("coin_gold");
                break;
        }
    }

    void Spawn()
    {
        for (int i = 0; i < maxCoins; i++)
        {
            
            Vector2 randomPosition = new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));

            //Choose the platform randomly
            this._coinType = Random.Range(1, 3);
            this.ChooseCoin(this._coinType);

            //Create platform
            Instantiate(coin, randomPosition, Quaternion.identity);

            this._originPosition = randomPosition;

        }
    }

}

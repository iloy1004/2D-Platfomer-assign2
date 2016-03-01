/*----------------------------------------------------------------------------
Source file name: HUD.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 26, 2016
Program description: This is for controlling of player's lives
Revision history: 0.0 - set up 
                  0.1 - made basic method
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    //Declare public vairables
    public Sprite[] HeartSprites;
    public Image HeartUI_1;
    public Image HeartUI_2;
    public Image HeartUI_3;
    public Image HeartUI_4;
    public Text Score;
    public PlayerController _Player;

    //Declare private variables
    private string _txtScore;



    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        this.DrawHUD(this._Player.curHealth);
        this.DrawScore(this._Player.score);
	}

    // Draw Current heart depends on player's current health score
    void DrawHUD(int curHealth)
    {
        switch (curHealth)
        {
            case 0:
                HeartUI_1.sprite = HeartSprites[1];
                HeartUI_2.sprite = HeartSprites[1];
                HeartUI_3.sprite = HeartSprites[1];
                HeartUI_4.sprite = HeartSprites[1];
                break;
            case 1:
                HeartUI_1.sprite = HeartSprites[0];
                HeartUI_2.sprite = HeartSprites[1];
                HeartUI_3.sprite = HeartSprites[1];
                HeartUI_4.sprite = HeartSprites[1];
                break;
            case 2:
                HeartUI_1.sprite = HeartSprites[0];
                HeartUI_2.sprite = HeartSprites[0];
                HeartUI_3.sprite = HeartSprites[1];
                HeartUI_4.sprite = HeartSprites[1];
                break;
            case 3:
                HeartUI_1.sprite = HeartSprites[0];
                HeartUI_2.sprite = HeartSprites[0];
                HeartUI_3.sprite = HeartSprites[1];
                HeartUI_4.sprite = HeartSprites[0];
                break;
            case 4:
            default:
                HeartUI_1.sprite = HeartSprites[0];
                HeartUI_2.sprite = HeartSprites[0];
                HeartUI_3.sprite = HeartSprites[0];
                HeartUI_4.sprite = HeartSprites[0];
                break;
        }
    }

    void DrawScore(int curScore)
    {
        this._txtScore = "Score: " + curScore;
        this.Score.text = this._txtScore;
    }
}

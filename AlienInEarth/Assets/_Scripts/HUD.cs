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

    //Declare private variables
    public PlayerController _Player;

	// Use this for initialization
	void Start () {

        //this._Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Debug.Log(this._Player.curHealth);

	}
	
	// Update is called once per frame
	void Update () {

        this.DrawHUD(this._Player.curHealth);
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
}

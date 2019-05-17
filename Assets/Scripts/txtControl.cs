using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class txtControl : MonoBehaviour
{

    public Text player;
    public Text coins;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("counter1") > 1)
        {
            player.text = "Congratulations Player 1";
            coins.text = "Total coins: " + PlayerPrefs.GetInt("coins1");
        }
        else
        {
            player.text = "Congratulations Player 2";
            coins.text = "Total coins: " + PlayerPrefs.GetInt("coins2");
        }
    }


}

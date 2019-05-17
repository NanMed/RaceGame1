using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerManager : MonoBehaviour
{
    public void ChooseWinner(int index)
    {
        PlayerPrefs.SetInt("winnerType", index);
        Debug.Log("The index is " + index);
    }

    public void selectMedal()
    {
        //Debug.Log(PlayerPrefs.GetInt("counter1") + "counter1");
        if (PlayerPrefs.GetInt("counter1") > 1)
        {
            //Set active the text
            if (PlayerPrefs.GetInt("coins1") <= 5)
            {
                ChooseWinner(2);
            }
            else if (PlayerPrefs.GetInt("coins1") > 5 && PlayerPrefs.GetInt("coins1") < 10)
            {
                ChooseWinner(1);
            }
            else if (PlayerPrefs.GetInt("coins1") >= 10)
            {
                ChooseWinner(0);
            }
        }

        if (PlayerPrefs.GetInt("counter2")>1)
        {
            //Set active the text
            if (PlayerPrefs.GetInt("coins2") <= 5)
            {
                ChooseWinner(2);
            }
            else if (PlayerPrefs.GetInt("coins2") > 5 && PlayerPrefs.GetInt("coins2") < 10)
            {
                ChooseWinner(1);
            }
            else if (PlayerPrefs.GetInt("coins2") >= 10)
            {
                ChooseWinner(0);
            }
        }
        
    }
}

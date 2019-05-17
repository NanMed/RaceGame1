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
        if (Car2dController.coins <= 5)
        {
            ChooseWinner(2);
        } else if (Car2dController.coins > 5 && Car2dController.coins < 10)
        {
            ChooseWinner(1);
        } else if (Car2dController.coins >= 10)
        {
            ChooseWinner(0);
        }

        if (CarControllerPlayer2.coins <= 5)
        {
            ChooseWinner(2);
        }
        else if (CarControllerPlayer2.coins > 5 && CarControllerPlayer2.coins < 10)
        {
            ChooseWinner(1);
        }
        else if (CarControllerPlayer2.coins >= 10)
        {
            ChooseWinner(0);
        }
    }
}

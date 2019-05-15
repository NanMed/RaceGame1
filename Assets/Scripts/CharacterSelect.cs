using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void ChooseCharacter(int index)
    {
        PlayerPrefs.SetInt("selectedCharacter", index);
        print("The index is " + index);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Level1");
    }

}

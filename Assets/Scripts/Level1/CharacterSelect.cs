using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void ChooseCharacter(int index)
    {
        PlayerPrefs.SetInt("selectedCharacter", index);
        Debug.Log("The index is " + index);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadTryScene2()
    {
        SceneManager.LoadScene("PruebaLevel2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level3");
    }

}

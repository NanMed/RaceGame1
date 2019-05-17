using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public void Play(){
        SceneManager.LoadScene("Instructions");
        Debug.Log("Instructions");
	}

    public void Restart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("Click");
    }

    public void toLevel2()
    {
        SceneManager.LoadScene("Level2");
        Debug.Log("Level2");
    }

    public void toLevelTry()
    {
        SceneManager.LoadScene("PruebaLevel2");
        Debug.Log("Level2");
    }

    public void toLevel3()
    {
        SceneManager.LoadScene("Level3");
        Debug.Log("Level3");
    }

    public void Next()
    {
        SceneManager.LoadScene("Items");
        Debug.Log("Items");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SelectPlayer");
        Debug.Log("SelectPlayer");
    }

    public void Winner()
    {
        SceneManager.LoadScene("Winner");
        Debug.Log("Winner");
    }
}

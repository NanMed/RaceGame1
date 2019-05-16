using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public void Play(){
        SceneManager.LoadScene("SelectPlayer");
        Debug.Log("Click");
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

    public void toLevel3()
    {
        SceneManager.LoadScene("Level3");
        Debug.Log("Level3");
    }
}

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
}

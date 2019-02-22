using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public void Play(){
		Application.LoadLevel("Level1");
		Debug.Log("Click");
	}
}

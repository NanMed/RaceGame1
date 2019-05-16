using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyAudio : MonoBehaviour
{
	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
}

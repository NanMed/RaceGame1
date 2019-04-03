using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {
	
     Image timerBar;
     public float maxTime = 7.0f;
     public float timeLeft;
     public GameObject timesUpText;

     void Start()
     {
         timeLeft = maxTime;
         timerBar = GetComponent<Image>();
	 timesUpText.SetActive(false);
     }

	void Update(){
		if(timeLeft > 0){
			timeLeft -= Time.deltaTime;
			timerBar.fillAmount = timeLeft / maxTime;
		}else{
			timesUpText.SetActive(true);
			Time.timeScale = 0;
		}
	}
 
}

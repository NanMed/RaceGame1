using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawned;
	float randX;
	Vector2 whereTo;
	public float spawnRate = 2f;
	float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + spawnRate;
			randX = Random.Range(-.4f, .4f);
			whereTo = new Vector2 (randX, transform.position.y);
			Instantiate(spawned, whereTo, Quaternion.identity);
			//GameObject.Destroy(gameObject, 2.0f);
		}


	}


}

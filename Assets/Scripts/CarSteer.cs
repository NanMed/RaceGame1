using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteer : MonoBehaviour {

	[SerializeField]	
	public Transform[] path;
	//private List<Transform> nodes;
	[SerializeField]	
	private float speed = 2f;

	private int currentNode = 0;
	//public float maxSteerAngle = 45f;
	//public WheelCollider wheels;

	// Use this for initialization
	void Start () {

	transform.position = path[currentNode].transform.position;



	
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		transform.position = Vector2.MoveTowards(transform.position, path[currentNode].transform.position, speed * Time.deltaTime);

		if(transform.position == path[currentNode].transform.position){
			currentNode += 1;
		}else if(currentNode == path.Length)
			currentNode = 0;
		
		}
	}

/*void ApplySteer(){
		Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
	Debug.Log(relativeVector);
	float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
	wheels.steerAngle = newSteer;
	}

	void Drive(){
		wheels.motorTorque = 100f;
		
	}*/	

/*Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
	nodes = new List<Transform>();

	for(int i = 0; i < pathTransforms.Length; i++){
		if(pathTransforms[i] != path.transform){
			nodes.Add(pathTransforms[i]);
		}
	}*/

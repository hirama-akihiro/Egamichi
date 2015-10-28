using UnityEngine;
using System.Collections;

public class GoalP : MonoBehaviour {
	GameObject Button;
	// Use this for initialization
	void Start () {
		Button=GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider A){
		if(A.gameObject.tag=="Ball"){
			Button.GetComponent<Button>().clear=true;
			A.GetComponent<Rigidbody>().velocity=Vector3.zero;
			A.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			A.GetComponent<Rigidbody>().useGravity=false;
			Button.GetComponent<TouchAbstraction>().GameEnd();
		}
	}
}

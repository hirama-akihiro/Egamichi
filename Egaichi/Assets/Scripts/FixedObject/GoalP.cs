using UnityEngine;
using System.Collections;

public class GoalP : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag=="Ball"){
			collider.GetComponent<Rigidbody>().velocity=Vector3.zero;
			collider.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			collider.GetComponent<Rigidbody>().useGravity=false;
			GameManager.I.gameState = GameManager.GameState.Clear;
		}
	}
}

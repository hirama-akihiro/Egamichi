using UnityEngine;
using System.Collections;

public class F_DFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Ball"){
			GameObject ball=collision.gameObject;
			ball.GetComponent<Rigidbody>().velocity=Vector3.zero;
			ball.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			ball.GetComponent<Rigidbody>().useGravity=false;
			GameManager.I.gameState = GameManager.GameState.Over;
		}
	}
}

using UnityEngine;
using System.Collections;

public class F_DFloor : MonoBehaviour {
	GameObject Button;
	// Use this for initialization
	void Start () {
		Button=GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision A){
		if(A.gameObject.tag=="Ball"){
			Button.GetComponent<Button>().over=true;
			GameObject ball=A.gameObject;
			ball.GetComponent<Rigidbody>().velocity=Vector3.zero;
			ball.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			ball.GetComponent<Rigidbody>().useGravity=false;
			Button.GetComponent<TouchAbstraction>().GameEnd();
		}
	}
}

using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public PhysicMaterial slide,bound;

	float MAXSPEED=10.0f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector3 BallSpeed = GetComponent<Rigidbody>().velocity;
		if(BallSpeed.x>=MAXSPEED){
			GetComponent<Rigidbody>().velocity=new Vector3(MAXSPEED,BallSpeed.y,0);
		}else if(BallSpeed.x<=MAXSPEED*-1){
			GetComponent<Rigidbody>().velocity=new Vector3(-1*MAXSPEED,BallSpeed.y,0);
		}
		if(BallSpeed.y>=MAXSPEED){
			GetComponent<Rigidbody>().velocity=new Vector3(BallSpeed.x,MAXSPEED,0);
		}else if(BallSpeed.y<MAXSPEED*-1){
			GetComponent<Rigidbody>().velocity=new Vector3(BallSpeed.x,-1*MAXSPEED,0);
		}
	
	}
	void OnCollisionEnter(Collision C){
		//GetComponent<SphereCollider>().material=slide;
		/*if(C.gameObject.tag=="Curve"){
			GetComponent<SphereCollider>().material=slide;
		}
		else if(GetComponent<SphereCollider>().material==bound){
			GetComponent<SphereCollider>().material=slide;
		}*/
	}
}

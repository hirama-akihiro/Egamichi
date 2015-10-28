using UnityEngine;
using System.Collections;

public class C_Jump : MonoBehaviour {
	public float Jumpforce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision A){
		if(A.gameObject.tag=="Ball"){
			GameObject ball=A.gameObject;
			ball.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, Jumpforce, 0.0f),ForceMode.VelocityChange);
		}
	}
	public void Delete(){
		Destroy(this);
	}
}

using UnityEngine;
using System.Collections;

public class F_Spin : MonoBehaviour {
	float RotateZ;
	public int SpinSpeed=100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float Speed=SpinSpeed*Time.deltaTime;
		RotateZ+=Speed;
		this.transform.rotation=Quaternion.Euler(0.0f,0.0f,RotateZ);
		if(RotateZ>=360)RotateZ=0;
	
	}
}

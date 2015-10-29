using UnityEngine;
using System.Collections;

public class C_Reflect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.rotation=Quaternion.Euler(90.0f,0.0f,0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Delete(){
		Destroy(this);
	}
}

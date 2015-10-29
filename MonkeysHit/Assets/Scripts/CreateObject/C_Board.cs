using UnityEngine;
using System.Collections;

public class C_Board : MonoBehaviour {
	public float RotateZ;
	public float ScaleX;


	// Use this for initialization
	void Start () {
		this.transform.localScale=new Vector3(ScaleX,0.4f,1.0f);
		this.transform.rotation=Quaternion.Euler(0.0f,0.0f,RotateZ);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Delete(){
		Destroy(this);
	}
}

using UnityEngine;
using System.Collections;

public class StartP : MonoBehaviour {
	public GameObject Ball;
	private GameObject b;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DropBall(){
		b = Instantiate(Ball, new Vector3(this.transform.position.x, this.transform.position.y, 0.0f), transform.rotation) as GameObject;
	}
	public void DeleteBall(){
		if (b) { Destroy(b); }
	}
	public void alpha_start(bool start){

		if (start) {
			GetComponent<MeshRenderer>().enabled=true;
			GetComponentInChildren<MeshRenderer>().enabled=true;
		} else if (!start) {
			GetComponent<MeshRenderer>().enabled=false;
			GetComponentInChildren<MeshRenderer>().enabled=false;
		}
	}
}

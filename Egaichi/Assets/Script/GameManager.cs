using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject C_Board;
	public GameObject C_Jump;
	public GameObject C_Curve;
	public GameObject C_Curve_p;
	public GameObject C_Curve_pshere;
	public GameObject C_GuideCurve;
	public GameObject C_GuideCurve_p;
	private GameObject C_pGuideCurve;
	public GameObject C_Reflect;
	private LinkedList<GameObject> CountedObj;
	private static int USER_OBJECT_LIMIT_NUM = 3;

	public static int SceneID = 1;

	// Use this for initialization
	void Start () {
		CountedObj = new LinkedList<GameObject> ();

		//試作用
		/*
		Vector3 A1=new Vector3(10.0f,-2.0f,0);
		Vector3 A2=new Vector3(9.0f,0.0f,0);
		Vector3 A3=new Vector3(8.0f,0.3f,0);
		Vector3 A4=new Vector3(7.0f,0.5f,0);
		Vector3 A5=new Vector3(6.0f,0.6f,0);
		Vector3 A6=new Vector3(5.0f,0.03f,0);
		Vector3 A7=new Vector3(4.0f,0.0f,0);
		Vector3 A8=new Vector3(3.0f,0.3f,0);
		Vector3 A9=new Vector3(2.0f,0.5f,0);
		Vector3 A10=new Vector3(1.0f,0.6f,0);
		Vector3[] As={A1,A2,A3,A4,A5,A6,A7,A8,A9,A10};
		*/
		//CreateCurve(As);
		//CreateBoard(A1,A2);
		//CreateReflect(A1*2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void CreateBoard(Vector3 p1,Vector3 p2){
		if(p1.x>=p2.x){
			Vector3 p=p1;
			p1=p2;
			p2=p;
		}
		float CreateP_x=(p1.x+p2.x)/2;
		float CreateP_y=(p1.y+p2.y)/2;
		float BoardS=Mathf.Sqrt((Mathf.Pow((p1.x-p2.x),2)+Mathf.Pow((p1.y-p2.y),2)));
		float CreateRZ=0.0f;
		if(p1.y>=p2.y){
			CreateRZ=180-(Mathf.Acos(Mathf.Abs(p1.x-p2.x)/BoardS)*180/Mathf.PI);
		}else if(p1.y<p2.y){
			CreateRZ=Mathf.Acos(Mathf.Abs(p1.x-p2.x)/BoardS)*180/Mathf.PI;
		}
		GameObject board=Instantiate(C_Board,new Vector3(CreateP_x,CreateP_y,0),transform.rotation)as GameObject;
		board.GetComponent<C_Board>().ScaleX=BoardS;
		board.GetComponent<C_Board>().RotateZ=CreateRZ;
		CountedObj.AddLast (board);
		Destroy_old();
	}
	public void CreateReflect(Vector3 p){
		GameObject reflect=Instantiate(C_Reflect,new Vector3(p.x,p.y,0),transform.rotation)as GameObject;
		CountedObj.AddLast (reflect);
		Destroy_old();
	}
	public void CreateJump(Vector3 p,float JPower){
		GameObject jump=Instantiate(C_Jump,new Vector3(p.x,p.y,0),transform.rotation)as GameObject;
		jump.GetComponent<C_Jump>().Jumpforce=JPower;
		CountedObj.AddLast (jump);
		Destroy_old();
	}
	public void CreateCurve(Vector3[] ps){
		GameObject curve=Instantiate(C_Curve,new Vector3(ps[0].x,ps[0].y,0),transform.rotation)as GameObject;
		int i=0,j=0;
		foreach(Vector3 p in ps){
			i++;
		}
		for(j=0;j<i-1;j++){
			Vector3 p1=ps[j];
			Vector3 p2=ps[j+1];
			GameObject sphere = Instantiate(C_Curve_pshere,p2,transform.rotation) as GameObject;
			sphere.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
			sphere.transform.parent = curve.transform;

			if(p1.x>=p2.x){
				Vector3 p=p1;
				p1=p2;
				p2=p;
			}
			float CreateP_x=(p1.x+p2.x)/2;
			float CreateP_y=(p1.y+p2.y)/2;
			float BoardS=Mathf.Sqrt((Mathf.Pow((p1.x-p2.x),2)+Mathf.Pow((p1.y-p2.y),2)));
			float CreateRZ=0.0f;
			if(p1.y>=p2.y){
				CreateRZ=180-(Mathf.Acos(Mathf.Abs(p1.x-p2.x)/BoardS)*180/Mathf.PI);
			}else if(p1.y<p2.y){
				CreateRZ=Mathf.Acos(Mathf.Abs(p1.x-p2.x)/BoardS)*180/Mathf.PI;
			}
			GameObject board=Instantiate(C_Curve_p,new Vector3(CreateP_x,CreateP_y,0),transform.rotation)as GameObject;
			board.GetComponent<Transform>().localScale=new Vector3(BoardS,0.2f,1.0f);
			board.GetComponent<Transform>().rotation=Quaternion.Euler(0.0f,0.0f,CreateRZ);
			board.GetComponent<Transform>().parent=curve.transform;
		}
		CountedObj.AddLast (curve);
		Destroy_old();
	}
	void Destroy_old(){
		while (CountedObj.Count > USER_OBJECT_LIMIT_NUM){
			Destroy (CountedObj.First.Value);
			CountedObj.RemoveFirst ();
		}
	}

	public void CreateGuideCurve(Vector3 p1, Vector3 p2){
		if (C_pGuideCurve == null) {
			C_pGuideCurve = Instantiate (C_GuideCurve);
		}
		if (p1.x >= p2.x) {
			Vector3 p = p1;
			p1 = p2;
			p2 = p;
		}
		float createPx = (p1.x + p2.x) / 2;
		float createPy = (p1.y + p2.y) / 2;
		float BoardS = Vector3.Distance (p1, p2);
		float createRZ = 0.0f;
		if (p1.y >= p2.y) {
			createRZ = 180 - (Mathf.Acos (Mathf.Abs (p1.x - p2.x) / BoardS) * 180 / Mathf.PI);
		} else if (p1.y < p2.y) {
			createRZ = Mathf.Acos (Mathf.Abs (p1.x - p2.x) / BoardS) * 180 / Mathf.PI;
		}
		GameObject board = Instantiate (C_GuideCurve_p, new Vector3 (createPx, createPy, 0), transform.rotation)as GameObject;
		board.GetComponent<Transform> ().localScale = new Vector3 (BoardS, 0.2f, 1.0f);
		board.GetComponent<Transform> ().rotation = Quaternion.Euler (0.0f, 0.0f, createRZ);
		board.GetComponent<Transform> ().parent = C_pGuideCurve.transform;
	}

	public void DestoryGuideCurve(){
		if (C_GuideCurve != null) {
			GameObject.Destroy(C_pGuideCurve);
		}
	}

	public void Reroad(){
		while (CountedObj.Count > 0){
			Destroy (CountedObj.First.Value);
			CountedObj.RemoveFirst ();
		}
	}
}

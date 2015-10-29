using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateManager : SingletonMonoBehavior<CreateManager> {

    #region 入力時に設置するオブジェクト
    public GameObject C_Board;
	public GameObject C_Jump;
	public GameObject C_Curve;
	public GameObject C_Curve_p;
	public GameObject C_Curve_pshere;
	public GameObject C_GuideCurve;
	public GameObject C_GuideCurve_p;
	private GameObject C_pGuideCurve;
	public GameObject C_Reflect;
    #endregion

	/// <summary>
	/// 生成されたオブジェクト一覧
	/// </summary>
    private LinkedList<GameObject> CountedObj;

	/// <summary>
	/// 画面内で生成出来る最大数
	/// </summary>
	private static int USER_OBJECT_LIMIT_NUM = 3;

	public static int SceneID = 1;

	// Use this for initialization
	void Start () {
		CountedObj = new LinkedList<GameObject> ();
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

	void Destroy_old(){
		while (CountedObj.Count > USER_OBJECT_LIMIT_NUM)
		{
			Destroy(CountedObj.First.Value);
			CountedObj.RemoveFirst();
		}
	}

	public void Reroad(){
		while (CountedObj.Count > 0){
			Destroy (CountedObj.First.Value);
			CountedObj.RemoveFirst ();
		}
	}
}

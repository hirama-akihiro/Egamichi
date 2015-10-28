using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public static int MAX_STAGE = 8;

	public bool start=true,clear=false,over=false;
	GameObject Startp,manager;

	public Texture startButtonTexture;
	public Texture retryButtonTexture;
	public Texture skipButtonTexture;

	public int tleft;
	public int ttop;

	public int twidth;
	public int theight;

	int sceneId;

	// Use this for initialization
	void Start () {
		init_Button();
		Startp=GameObject.Find("StartPoint");
		manager=GameObject.Find ("GameManager");
		//Goalp=GameObject.Find("/GoalPoint");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(over){
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50, 200, 100),retryButtonTexture)){
				Startp.GetComponent<StartP>().DeleteBall();
				manager.GetComponent<GameManager>().Reroad();
				start=true;
				over=false;
			}
		}else if(start){
			Startp.GetComponent<StartP>().alpha_start(start);
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50, 200, 100), startButtonTexture)){
				start=false;
				Startp.GetComponent<StartP>().alpha_start(start);
				manager.GetComponent<TouchAbstraction>().GameStart();
				Startp.GetComponent<StartP>().DropBall();
			}
		}else if(clear){
			if(GUI.Button(new Rect(Screen.width/2-100.0f,Screen.height/2-50.0f, 200.0f, 100.0f), "Clear!\nPlay NextStage")){
				GotoNextStage();
			}
		}
		if (GUI.Button (new Rect (15, 10, 120, 60), skipButtonTexture)) {
			GotoNextStage ();
		}
		
		if (GUI.Button (new Rect (Screen.width - 135, 10, 120, 60), retryButtonTexture)) {
			Startp.GetComponent<StartP> ().DeleteBall ();
			manager.GetComponent<GameManager> ().Reroad ();
			manager.GetComponent<TouchAbstraction> ().GameEnd ();
			init_Button ();
		}
	}

	void init_Button(){
		start=true;
		clear=false;
		over=false;
	}

	private void GotoNextStage()
	{
		GameManager.SceneID++;
		if(GameManager.SceneID > MAX_STAGE){
			GameManager.SceneID = 1;
		}
		Application.LoadLevel("ProtoScene"+GameManager.SceneID);
	}
}

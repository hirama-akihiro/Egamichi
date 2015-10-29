using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTapStage01()
	{
		Debug.Log("stage01");
		StageNumber.stageNumber = 0;
		Application.LoadLevel("Game");
	}

	public void OnTapStage02()
	{
		StageNumber.stageNumber = 1;
		Application.LoadLevel("Game");
	}

	public void OnTapStage03()
	{
		StageNumber.stageNumber = 2;
		Application.LoadLevel("Game");
	}

	public void OnTapStage04()
	{
		StageNumber.stageNumber = 3;
		Application.LoadLevel("Game");
	}

	public void OnTapStage05()
	{
		StageNumber.stageNumber = 4;
		Application.LoadLevel("Game");
	}

	public void OnTapStage06()
	{
		StageNumber.stageNumber = 5;
		Application.LoadLevel("Game");
	}

	public void OnTapStage07()
	{
		StageNumber.stageNumber = 6;
		Application.LoadLevel("Game");
	}

	public void OnTapStage08()
	{
		StageNumber.stageNumber = 7;
		Application.LoadLevel("Game");
	}

	public void OnTapStage09()
	{
		StageNumber.stageNumber = 8;
		Application.LoadLevel("Game");
	}
}

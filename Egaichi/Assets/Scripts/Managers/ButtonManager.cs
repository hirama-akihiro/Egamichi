using UnityEngine;
using System.Collections;

public class ButtonManager : SingletonMonoBehavior<ButtonManager> {

	/// <summary>
	/// スタート地点
	/// </summary>
	private GameObject startP;

	/// <summary>
	/// リトライボタン
	/// </summary>
	public GameObject retryButton;

	/// <summary>
	/// スタートボタン
	/// </summary>
	public GameObject startButton;

	/// <summary>
	/// 再スタートボタン
	/// </summary>
	public GameObject reStartButton;

	// Use this for initialization
	void Start () {
		startP = GameObject.Find("StartPoint");
	}
	
	// Update is called once per frame
	void Update () {
		switch(GameManager.I.gameState)
		{
			case GameManager.GameState.Start:
				Debug.Log(startButton);
				startButton.SetActive(true);
				reStartButton.SetActive(false);
				break;
			case GameManager.GameState.Game:
				startButton.SetActive(false);
				reStartButton.SetActive(false);
				break;
			case GameManager.GameState.Clear:
				startButton.SetActive(false);
				reStartButton.SetActive(false);
				break;
			case GameManager.GameState.Over:
				startButton.SetActive(false);
				reStartButton.SetActive(true);
				break;
		}
	}

	/// <summary>
	/// Startボタンタッチ時のイベント
	/// </summary>
	public void OnTouchStart()
	{
		startP.GetComponent<StartP>().alpha_start(false);
		CreateManager.I.Reroad();
		startP.GetComponent<StartP>().DeleteBall();
		startP.GetComponent<StartP>().DropBall();
		GameManager.I.gameState = GameManager.GameState.Game;
	}

	/// <summary>
	/// Retryボタンタッチ時のイベント
	/// </summary>
	public void OnTouchRetry()
	{
		startP.GetComponent<StartP>().DeleteBall();
		CreateManager.I.Reroad();
		GameManager.I.gameState = GameManager.GameState.Start;
	}

	private void GotoNextStage()
	{
		//GameManager.SceneID++;
		//if(GameManager.SceneID > MAX_STAGE){
		//	GameManager.SceneID = 1;
		//}
		//Application.LoadLevel("ProtoScene"+GameManager.SceneID);
	}
}

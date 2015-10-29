using UnityEngine;
using System.Collections;

public class ButtonManager : SingletonMonoBehavior<ButtonManager> {

	/// <summary>
	/// スタート地点
	/// </summary>
	public GameObject startP;

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

	/// <summary>
	/// メニューに戻るボタン
	/// </summary>
	public GameObject backButton;
	
	/// <summary>
	/// クリアメッセージ
	/// </summary>
	public GameObject clearMessage;

	// Use this for initialization
	void Start () {
		startP = GameObject.Find("StartPoint");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GameManager.I.gameState);
		switch(GameManager.I.gameState)
		{
			case GameManager.GameState.Start:
				Debug.Log(startButton);
				retryButton.SetActive(false);
				startButton.SetActive(true);
				reStartButton.SetActive(false);
				backButton.SetActive(true);
				break;
			case GameManager.GameState.Game:
				retryButton.SetActive(true);
				startButton.SetActive(false);
				reStartButton.SetActive(false);
				backButton.SetActive(false);
				break;
			case GameManager.GameState.Clear:
				retryButton.SetActive(false);
				startButton.SetActive(false);
				reStartButton.SetActive(false);
				backButton.SetActive(false);
				clearMessage.SetActive(true);
				if (CrossInput.I.IsDown())
				{
					OnTouchRetry();
					clearMessage.SetActive(false);
					SceneStateManager.I.LoadLevel(1);
				}
				break;
			case GameManager.GameState.Over:
				retryButton.SetActive(false);
				startButton.SetActive(false);
				reStartButton.SetActive(true);
				backButton.SetActive(true);
				break;
		}
	}

	/// <summary>
	/// Startボタンタッチ時のイベント
	/// </summary>
	public void OnTouchStart()
	{
		AudioManager.I.PlayAudio("seSelect");
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
		AudioManager.I.PlayAudio("seSelect");
		startP.GetComponent<StartP>().DeleteBall();
		CreateManager.I.Reroad();
		GameManager.I.gameState = GameManager.GameState.Start;
	}

	public void OnTouchBack()
	{
		AudioManager.I.PlayAudio("seSelect");
		startP.GetComponent<StartP>().DeleteBall();
		CreateManager.I.Reroad();
		GameManager.I.gameState = GameManager.GameState.Start;
		SceneStateManager.I.LoadLevel(1);
	}
}

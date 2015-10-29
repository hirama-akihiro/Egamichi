using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehavior<GameManager> {

	/// <summary>
	/// ゲームの状態
	/// </summary>
	public enum GameState { Start, Game, Clear, Over }

	/// <summary>
	/// ゲームの状態
	/// </summary>
	public GameState gameState = GameState.Start;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

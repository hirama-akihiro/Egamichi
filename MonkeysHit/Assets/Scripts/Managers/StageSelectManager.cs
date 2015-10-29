using UnityEngine;
using System.Collections;

public class StageSelectManager : SingletonMonoBehavior<StageSelectManager> {

	/// <summary>
	/// ステージ
	/// </summary>
	public GameObject[] stages;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectStage(int stageNo)
	{
		foreach (var stage in stages)
			stage.SetActive(false);

		stages[stageNo].SetActive(true);
	}
}

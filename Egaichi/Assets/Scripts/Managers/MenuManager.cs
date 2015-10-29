using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : SingletonMonoBehavior<MenuManager> {

	/// <summary>
	/// メニューオブジェクト
	/// </summary>
	public GameObject[] menuObjects;

	/// <summary>
	/// クリアしたステージに使用する画像
	/// </summary>
	public Sprite clearMenuSprite;

	/// <summary>
	/// クリアしていないステージに使用する画像
	/// </summary>
	public Sprite noClearMenuSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTapStage01()
	{
		StageNumber.stageNumber = 0;
		TapStage();
	}

	public void OnTapStage02()
	{
		StageNumber.stageNumber = 1;
		TapStage();
	}

	public void OnTapStage03()
	{
		StageNumber.stageNumber = 2;
		TapStage();
	}

	public void OnTapStage04()
	{
		StageNumber.stageNumber = 3;
		TapStage();
	}

	public void OnTapStage05()
	{
		StageNumber.stageNumber = 4;
		TapStage();
    }

	public void OnTapStage06()
	{
		StageNumber.stageNumber = 5;
		TapStage();
    }

	public void OnTapStage07()
	{
		StageNumber.stageNumber = 6;
		TapStage();
    }

	public void OnTapStage08()
	{
		StageNumber.stageNumber = 7;
		TapStage();
    }

	public void OnTapStage09()
	{
		StageNumber.stageNumber = 8;
		TapStage();
    }

	private void TapStage()
	{
		AudioManager.I.PlayAudio("seSelect");
		SceneStateManager.I.LoadLevel(2);
		StageSelectManager.I.SelectStage(StageNumber.stageNumber);
		ButtonManager.I.startP = GameObject.Find("StartPoint");
	}

	/// <summary>
	/// 各ステージのクリア状況を反映
	/// </summary>
	public void ClearSituationReflection()
	{
		for(int i = 0; i < menuObjects.Length;i++)
		{
			int isClear = PlayerPrefs.GetInt("Stage" + i, 0);
			Debug.Log(isClear);
			if (isClear == 1) menuObjects[i].GetComponent<Image>().sprite = clearMenuSprite;
			else { menuObjects[i].GetComponent<Image>().sprite = noClearMenuSprite; }
		}
	}
}

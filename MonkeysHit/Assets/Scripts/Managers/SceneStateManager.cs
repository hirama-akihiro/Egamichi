using UnityEngine;
using System.Collections;

public class SceneStateManager : SingletonMonoBehavior<SceneStateManager> {

	/// <summary>
	/// シーンオブジェクト
	/// </summary>
	public GameObject[] sceneObjects;

	// Use this for initialization
	void Start () {
		LoadLevel(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int sceneNo)
	{
		foreach (var scene in sceneObjects)
			scene.SetActive(false);

		sceneObjects[sceneNo].SetActive(true);
		switch(sceneNo)
		{
			case 1:
				MenuManager.I.ClearSituationReflection();
				break;
		}
	}
}

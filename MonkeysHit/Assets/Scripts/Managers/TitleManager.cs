using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioManager.I.PlayAudio("bgm", AudioManager.PlayMode.Repeat);
	}
	
	// Update is called once per frame
	void Update () {
		if(!Application.isShowingSplashScreen && CrossInput.I.IsDown())
		{
			AudioManager.I.PlayAudio("seSelect");
			SceneStateManager.I.LoadLevel(1);
		}
	}
}

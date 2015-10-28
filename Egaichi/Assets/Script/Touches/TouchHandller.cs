using UnityEngine;
using System.Collections;

public class TouchHandller : MonoBehaviour {
	/// <summary>
	/// The is previous touch.
	/// </summary>
	private bool isPrevTouch;
	/// <summary>
	/// The is now touch.
	/// </summary>
	private bool isNowTouch;

	// Use this for initialization
	protected void Start () {
		isPrevTouch = false;
		isNowTouch = false;
	}
	
	// Update is called once per frame
	protected void Update () {
		isNowTouch = Input.touchCount > 0;
		if (IsTouchDown ()) {
			TouchBegin ();
		} else if (IsTouching ()) {
			TouchMove ();
		} else if (IsTouchUp ()) {
			TouchEnd ();
		}
		isPrevTouch = isNowTouch;
	}

	protected virtual void TouchBegin(){
	}

	protected virtual void TouchMove(){
	}

	protected virtual void TouchEnd(){
	}

	protected bool IsTouchDown(){
		return !isPrevTouch && isNowTouch;
	}
	
	protected bool IsTouching(){
		return isPrevTouch && isNowTouch;
	}
	
	protected bool IsTouchUp(){
		return isPrevTouch && !isNowTouch;
	}
	
	public void GameStart(){
		enabled     = true;
		isPrevTouch = false;
		isNowTouch  = false;
	}
	
	public void GameEnd(){
		enabled     = false;
		isPrevTouch = false;
		isNowTouch  = false;
	}
}

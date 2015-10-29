using UnityEngine;
using System.Collections;

public class TouchHandller : MonoBehaviour {

	/// <summary>
	/// 前フレームでタッチしているか
	/// </summary>
	private bool isPrevTouch;

	/// <summary>
	/// 現フレームでタッチしているか
	/// </summary>
	private bool isNowTouch;

	// Use this for initialization
	protected void Start () {
		isPrevTouch = false;
		isNowTouch = false;
	}
	
	// Update is called once per frame
	protected void Update () {
		isNowTouch = CrossInput.I.IsMove();
		if (IsTouchDown()) {
			TouchBegin ();
		} else if (IsTouchMove()) {
			TouchMove ();
		} else if (IsTouchUp()) {
			TouchEnd ();
		}
		isPrevTouch = isNowTouch;
	}

    /// <summary>
    /// タッチ開始時に呼ばれるメソッド
    /// </summary>
	protected virtual void TouchBegin() { }

    /// <summary>
    /// タッチ中に呼ばれるメソッド
    /// </summary>
	protected virtual void TouchMove() { }

    /// <summary>
    /// タッチ終了時に呼ばれるメソッド
    /// </summary>
	protected virtual void TouchEnd() { }

	private bool IsTouchDown() { return !isPrevTouch && isNowTouch; }
	private bool IsTouchMove() { return isPrevTouch && isNowTouch; }
	private bool IsTouchUp() { return isPrevTouch && !isNowTouch; }
	
	public void GameStart(){
        enabled = true;
	}
	
	public void GameEnd(){
        enabled = false;
	}
}

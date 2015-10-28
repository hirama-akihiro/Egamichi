using UnityEngine;
using System.Collections;

public class FingerTypeCheck : MonoBehaviour {

	/// <summary>
	/// The singleton.
	/// </summary>
	private static FingerTypeCheck singleton = new FingerTypeCheck();

	/// <summary>
	/// タッチ始点から終点までの距離がこれ以下であればタップとみなす
	/// </summary>
	private float toleranceDistance = 30.0f;

	/// <summary>
	/// タッチ始点からの距離が、この値より大きくなったあとこの値以下に戻ってきたら円を描いたとみなす
	/// </summary>
	private float toleranceCircleDistance = 60.0f;

	/// <summary>
	/// 2点のタッチ開始の時間差・タッチ終了の時間差がこれ以下であれば同時タッチとみなす
	/// </summary>
	private float toleranceTime = 1.0f;

	private enum FingerType{ SingleTap, SingleTrace, SingleCircle, DoubleTap};

	public static FingerTypeCheck Instance { get { return singleton;}}

	// Use this for i nitialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// Determines whether this instance is tap the specified finger.
	/// </summary>
	/// <returns><c>true</c> if this instance is tap the specified finger; otherwise, <c>false</c>.</returns>
	/// <param name="finger">Finger.</param>
	public bool IsTap(Finger finger){
		for (int i = 0; i < finger.Positions.Count; i++) {
			if(Vector2.Distance(finger.Positions[0],finger.Positions[i]) > toleranceDistance){
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Determines whether this instance is tracing the specified finger.
	/// </summary>
	/// <returns><c>true</c> if this instance is tracing the specified finger; otherwise, <c>false</c>.</returns>
	/// <param name="finger">Finger.</param>
	public bool IsTracing(Finger finger){
		return !IsTap (finger);
	}

	/// <summary>
	/// Determines whether this instance is circle the specified finger.
	/// </summary>
	/// <returns><c>true</c> if this instance is circle the specified finger; otherwise, <c>false</c>.</returns>
	/// <param name="finger">Finger.</param>
	public bool IsCircle(Finger finger){
		bool isLongTrace = false;
		for (int i = 0; i < finger.Positions.Count; i++) {
			if (!isLongTrace) {
				if (Vector2.Distance (finger.Positions [0], finger.Positions [i]) >= toleranceCircleDistance) {
					isLongTrace = true;
				}
			} else{
				if (Vector2.Distance (finger.Positions [0], finger.Positions [i]) < toleranceCircleDistance) {
					finger.Positions.RemoveRange (i, finger.Positions.Count - i);
					return true;
				}
			}
		}
		return false;
	}

	/// <summary>
	/// Determines whether this instance is double tap the specified finger1 finger2.
	/// </summary>
	/// <returns><c>true</c> if this instance is double tap the specified finger1 finger2; otherwise, <c>false</c>.</returns>
	/// <param name="finger1">Finger1.</param>
	/// <param name="finger2">Finger2.</param>
	public bool IsDoubleTap(Finger finger1,Finger finger2){
		if (!IsTap (finger1) || !IsTap (finger2)) {
			return false;
		}
		if (Mathf.Abs (finger1.Times [0] - finger2.Times [0]) > toleranceTime) {
			return false;
		}
		if (Mathf.Abs (finger1.Times [finger1.Times.Count - 1] - finger2.Times [finger2.Times.Count - 1]) > toleranceTime) {
			return false;
		}
		return true;
	}
}

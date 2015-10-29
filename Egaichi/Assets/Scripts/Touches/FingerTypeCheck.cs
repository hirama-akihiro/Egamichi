using UnityEngine;
using System.Collections;

public class FingerTypeCheck : SingletonMonoBehavior<FingerTypeCheck> {

	/// <summary>
	/// タッチ始点から終点までの距離がこれ以下であればタップとみなす
	/// </summary>
	private float toleranceDistance = 30.0f;

	/// <summary>
	/// タッチ始点からの距離が、この値より大きくなったあとこの値以下に戻ってきたら円を描いたとみなす
	/// </summary>
	private float toleranceCircleDistance = 60.0f;

    /// <summary>
    /// 指入力の種類
    /// </summary>
    private enum FingerType { SingleTap, SingleTrace, SingleCircle }

	// Use this for i nitialization
	void Start () {
        DontDestroyOnLoad(gameObject);
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
        for (int i = 0; i < finger.Positions.Count; i++)
        {
            if (Vector2.Distance(finger.Positions[0], finger.Positions[i]) > toleranceDistance)
            {
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
}

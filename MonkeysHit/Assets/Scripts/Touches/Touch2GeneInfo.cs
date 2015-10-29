using UnityEngine;
using System.Collections.Generic;

public class Touch2GeneInfo : SingletonMonoBehavior<Touch2GeneInfo> {

	private static float JUMP_POWER_MULTIPLIER = 0.1f;

	private static Touch2GeneInfo singleton = new Touch2GeneInfo();

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public GeneInfo.GeneInfoC_Reflect Finger2C_Reflect(Finger finger){
		Vector3 point = Camera.main.ScreenToWorldPoint (finger.Positions [0]);
		point.z = 0;
		Debug.LogFormat ("Reflet:ScreenPoint {0},{1}", finger.Positions [0].x, finger.Positions [0].y);
		Debug.LogFormat ("Reflet:WorldPoint {0},{1}", point.x, point.y);
		return new GeneInfo.GeneInfoC_Reflect (point);
	}

	public GeneInfo.GeneInfoC_Curve Finger2C_Curbe(Finger finger){
		List<Vector3> pts = new List<Vector3> ();
		for (int i = 0; i < finger.Positions.Count; i++) {
			Vector3 pt = Camera.main.ScreenToWorldPoint(finger.Positions[i]);
			pt.z = 0;
			pts.Add(pt);
		}
		return new GeneInfo.GeneInfoC_Curve (pts);
	}

	public GeneInfo.GeneInfoC_GuideCurve Finger2C_GuideCurve(Vector3 pt1,Vector3 pt2){
		Vector3 guidePt1 = Camera.main.ScreenToWorldPoint(pt1);
		Vector3 guidePt2 = Camera.main.ScreenToWorldPoint(pt2);
		return new GeneInfo.GeneInfoC_GuideCurve(guidePt1,guidePt2);
	}

	public GeneInfo.GeneInfoC_Jump Finger2C_Jump(Finger finger){
		Vector3 meanPt = Camera.main.ScreenToWorldPoint (finger.Positions [0]);
		float range = 0.0f;
		for (int i = 0; i < finger.Positions.Count; i++) {
			Vector3 pt = Camera.main.ScreenToWorldPoint(finger.Positions[i]);
			meanPt += pt;
		}
		meanPt /= finger.Positions.Count;
		for (int i = 0; i < finger.Positions.Count; i++) {
			float dist = Vector2.Distance(finger.Positions[0],finger.Positions[i]);
			if(range < dist){
				range = dist;
			}
		}
		return new GeneInfo.GeneInfoC_Jump (meanPt, range * JUMP_POWER_MULTIPLIER);
	}

	public GeneInfo.GeneInfoC_Board Finger2C_Borard(Finger finger0, Finger finger1){
		Vector3 p1 = Camera.main.ScreenToWorldPoint (finger0.Positions [0]);
		Vector3 p2 = Camera.main.ScreenToWorldPoint (finger1.Positions [0]);
		p1.z = 0f;
		p2.z = 0f;

		Debug.LogFormat ("Board:ScreenPoint {0},{1},{2},{3}", finger0.Positions [0].x, finger0.Positions [0].y, finger1.Positions [0].x, finger1.Positions [0].y);
		Debug.LogFormat ("Board:WorldPoint {0},{1},{2},{3}", p1.x, p1.y, p2.x, p2.y);
		return new GeneInfo.GeneInfoC_Board (p1, p2);
	}
}

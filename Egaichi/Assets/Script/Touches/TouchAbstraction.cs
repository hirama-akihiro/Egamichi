using UnityEngine;
using System.Collections.Generic;

public class TouchAbstraction : TouchHandller {

	/// <summary>
	/// The finger dict.
	/// </summary>
	private Dictionary<int, Finger> fingerDict;
	public int tyousei=1100;

	private GameManager gameManager;

	private float toleranceDistance = 10.0f;

	// Use this for initialization
	protected new void Start () {
		base.Start ();
		fingerDict = new Dictionary<int, Finger> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	protected new void Update () {
		base.Update ();
	}

	protected override void TouchBegin(){
		Debug.LogFormat ("TouchBegin");
		fingerDict = new Dictionary<int, Finger> ();
	}

	protected override void TouchMove(){ 
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			Vector2 position = touch.position;

#if UNITY_EDITOR

			position.x += tyousei;
#endif

			Debug.LogFormat ("TouchMove {0}, {1}", position.x, position.y);
			if (!fingerDict.ContainsKey (touch.fingerId)) {
				fingerDict.Add (touch.fingerId, gameObject.AddComponent<Finger>());
				fingerDict [touch.fingerId].AddParam (position, Time.time);
			}

			if(Vector2.Distance(position,fingerDict[touch.fingerId].Positions[fingerDict[touch.fingerId].Positions.Count -1]) > toleranceDistance){
				// 軌跡の表示
				if(fingerDict[touch.fingerId].Positions.Count > 0 && fingerDict.Count == 1){
					GeneInfo.GeneInfoC_GuideCurve guideJump = Touch2GeneInfo.Instance.Finger2C_GuideCurve(fingerDict[touch.fingerId].Positions[fingerDict[touch.fingerId].Positions.Count-1],position);
					gameManager.CreateGuideCurve(guideJump.pt1,guideJump.pt2);
				}else if(fingerDict.Count > 1){
					gameManager.DestoryGuideCurve();
				}

				fingerDict [touch.fingerId].AddParam (position, Time.time);
			}
		}
	}

	protected override void TouchEnd(){
		var fingerIdList = new List<KeyValuePair<int,Finger>> (fingerDict);
		if (fingerDict.Count == 1) {
			var finger = fingerDict[fingerIdList[0].Key];
			if(FingerTypeCheck.Instance.IsTap(finger)){
				Debug.Log("SingleTap");
				GeneInfo.GeneInfoC_Reflect reflect = Touch2GeneInfo.Instance.Finger2C_Reflect(finger);
				gameManager.CreateReflect(reflect.pt);
			}else if(FingerTypeCheck.Instance.IsCircle(finger)){
				Debug.Log("SingleCircle");
				GeneInfo.GeneInfoC_Jump jump = Touch2GeneInfo.Instance.Finger2C_Jump(finger);
				gameManager.CreateJump(jump.pt,jump.power);
			}else if(FingerTypeCheck.Instance.IsTracing(finger)){
				Debug.Log("SingleTrace");
				GeneInfo.GeneInfoC_Curve curve = Touch2GeneInfo.Instance.Finger2C_Curbe(finger);
				gameManager.CreateCurve(curve.pts);
			}
		} else if (fingerDict.Count == 2) {
			var finger0 = fingerDict[fingerIdList[0].Key];
			var finger1 = fingerDict[fingerIdList[1].Key];
			if(FingerTypeCheck.Instance.IsDoubleTap(finger0,finger1)){
				Debug.Log("DoubleTap");

				GeneInfo.GeneInfoC_Board board = Touch2GeneInfo.Instance.Finger2C_Borard(finger0,finger1);
				gameManager.CreateBoard(board.p1,board.p2);
			}
		}
		gameManager.DestoryGuideCurve ();
	}
}

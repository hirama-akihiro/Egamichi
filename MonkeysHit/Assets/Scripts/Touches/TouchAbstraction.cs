using UnityEngine;
using System.Collections.Generic;

public class TouchAbstraction : TouchHandller {

    /// <summary>
    /// 指(マウス)の入力情報データクラス
    /// </summary>
    private Finger finger;

    /// <summary>
    /// このパラメータ以上距離がある場合に入力有りとして情報保持
    /// </summary>
	private float toleranceDistance = 10.0f;

	// Use this for initialization
	protected new void Start () {
		base.Start ();
        finger = new Finger();
	}
	
	// Update is called once per frame
	protected new void Update () {
		if (GameManager.I.gameState != GameManager.GameState.Game) { return; }
		base.Update ();
	}

	protected override void TouchBegin(){
		
	}

    protected override void TouchMove()
    {
        Vector2 position = CrossInput.I.ScreenPosition;
		if(finger.Positions.Count == 0) { finger.AddParam(position, Time.time); return; }
        if (Vector2.Distance(position, finger.Positions[finger.Positions.Count - 1]) > toleranceDistance )
        {
            // 軌跡の表示
            if (finger.Positions.Count > 0)
            {
                GeneInfo.GeneInfoC_GuideCurve guideJump = Touch2GeneInfo.I.Finger2C_GuideCurve(finger.Positions[finger.Positions.Count - 1], position);
                CreateManager.I.CreateGuideCurve(guideJump.pt1, guideJump.pt2);
            }
            finger.AddParam(position, Time.time);
        }
    }

    protected override void TouchEnd()
    {
		if(finger.Positions.Count == 0) { return; }
        if (FingerTypeCheck.I.IsTap(finger))
        {
            Debug.Log("SingleTap");
            GeneInfo.GeneInfoC_Reflect reflect = Touch2GeneInfo.I.Finger2C_Reflect(finger);
			CreateManager.I.CreateReflect(reflect.pt);
        }
        else if (FingerTypeCheck.I.IsCircle(finger))
        {
            Debug.Log("SingleCircle");
            GeneInfo.GeneInfoC_Jump jump = Touch2GeneInfo.I.Finger2C_Jump(finger);
			CreateManager.I.CreateJump(jump.pt, jump.power);
        }
        else if (FingerTypeCheck.I.IsTracing(finger))
        {
            Debug.Log("SingleTrace");
            GeneInfo.GeneInfoC_Curve curve = Touch2GeneInfo.I.Finger2C_Curbe(finger);
			CreateManager.I.CreateCurve(curve.pts);
        }
		CreateManager.I.DestoryGuideCurve();
		finger = new Finger();
	}
}

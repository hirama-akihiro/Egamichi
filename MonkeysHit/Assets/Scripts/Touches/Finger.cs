using UnityEngine;
using System.Collections.Generic;

public class Finger : MonoBehaviour {

	#region
	/// <summary>
	/// The position list.
	/// </summary>
	private List<Vector2> posList;

	/// <summary>
	/// The time list.
	/// </summary>
	private List<float> timeList;
	#endregion

	public Finger(){
		posList = new List<Vector2> ();
		timeList = new List<float> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPostion(Vector2 position){
		posList.Add (position);
	}

	public void ClearPosition(){
		posList.Clear ();
	}

	public void AddTime(float time){
		timeList.Add (time);
	}

	public void ClearTime(){
		timeList.Clear ();
	}

	public void AddParam(Vector2 position, float time){
		posList.Add (position);
		timeList.Add (time);
	}

	public List<Vector2> Positions {get{return posList;}}
	public List<float> Times{ get { return timeList; } }
}

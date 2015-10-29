using UnityEngine;
using System.Collections.Generic;

public class GeneInfo : MonoBehaviour {

	public struct GeneInfoC_Board{
		public Vector3 p1;
		public Vector3 p2;

		public GeneInfoC_Board(Vector3 p1, Vector3 p2){
			this.p1 = p1;
			this.p2 = p2;
		}
	}

	public struct GeneInfoC_Curve{
		public Vector3[] pts;
		public GeneInfoC_Curve(List<Vector3> pts){
			this.pts = pts.ToArray();
		}
	}

	public struct GeneInfoC_GuideCurve{
		public Vector3 pt1;
		public Vector3 pt2;
		public GeneInfoC_GuideCurve(Vector3 pt1,Vector3 pt2){
			this.pt1 = pt1;
			this.pt2 = pt2;
		}
	}

	public struct GeneInfoC_Jump{
		public Vector3 pt;
		public float power;
		public GeneInfoC_Jump(Vector3 pt, float power){
			this.pt = pt;
			this.power = power;
		}
	}

	public struct GeneInfoC_Reflect{
		public Vector3 pt;
		public GeneInfoC_Reflect(Vector3 pt){
			this.pt = pt;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

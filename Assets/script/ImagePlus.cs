using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImagePlus :Image {
	private RectTransform rect;
	private bool isin=false;
	PolygonCollider2D _collider;
	 void Awake()
	{
		rect = GetComponent<RectTransform> ();
		_collider = GetComponent<PolygonCollider2D>();

	}

	//将Input.mouseposition传入方法内
	override public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		//Debug.Log (sp+"------"+Input.mousePosition.x+"-------"+Input.mousePosition.y);
		isin=ContainsPoint(_collider.points,sp);
		return ContainsPoint(_collider.points,new Vector3(sp.x,sp.y,0));
	}
	bool ContainsPoint ( Vector2[]polyPoints, Vector3 p) { 
		Vector3 temp = Camera.main.WorldToScreenPoint (p);
		int j = polyPoints.Length-1; 
		bool inside = false; 
		for (int i = 0; i < polyPoints.Length; j = i++) { 
			
			polyPoints[i].x+=transform.position.x;
			polyPoints[i].y+=transform.position.y;
			//Debug.Log (p+"polyPoints[i]"+polyPoints[i]);
//			
			if ( ((polyPoints[i].y <= p.y && p.y < polyPoints[j].y) || 
				(polyPoints[j].y <= p.y && p.y < polyPoints[i].y)) && 
				((p.x < (polyPoints[j].x - polyPoints[i].x) * 
				(p.y - polyPoints[i].y) / (polyPoints[j].y - polyPoints[i].y) + polyPoints[i].x))
				) 
				inside = !inside; 
		} 
		return inside; 
	}

	void Update()
	{
		if (isin) {
			GetComponent<Image> ().color = Color.black;
		} else {
			GetComponent<Image> ().color = Color.red;
		}
	}


}

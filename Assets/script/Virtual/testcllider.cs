using UnityEngine;
using System.Collections;

public class testcllider : MonoBehaviour {
	public bool isalive;
	LayerMask floor;
	// Use this for initialization
	void Start () {
		floor = LayerMask.GetMask ("Floor");
		test ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton(0)) {
			Ray camray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.transform.position,Vector3.Normalize(Input.mousePosition-Camera.main.transform.position),out hit)) {
				if (hit.collider) {
					Debug.Log ("碰撞"+hit.collider.gameObject.name);
				}
			}
		}
	}
	public void OnMouseDown()
	{
		Debug.Log ("Down"+Camera.main.WorldToScreenPoint(Input.mousePosition)+"----"+Input.mousePosition);
	}

	void OnDestroy()
	{
		Debug.Log ("ONDESTROY");
	}
	~testcllider(){
		Debug.Log ("destroy");
	}
	public virtual void test()
	{
		Debug.Log ("a virtual");
	}

}

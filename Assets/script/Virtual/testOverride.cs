using UnityEngine;
using System.Collections;

public class testOverride : testcllider {


	void Start () {
		test ();
		base.OnMouseDown ();
	}
	public override void test ()
	{
		base.test ();
		Debug.Log ("a new place to creat");
	}

	void Update () {
	
	}
}

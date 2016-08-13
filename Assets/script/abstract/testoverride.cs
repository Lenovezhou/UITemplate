using UnityEngine;
using System.Collections;

public class testoverride : testabstract {


	// Use this for initialization
	void Start ()
	{
		callback ();
		fathersfonction ();
	}
	public override void fathersfonction ()
	{
		Debug.Log ("Childeren ");
		// throw new System.NotImplementedException ();
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void callback()
	{
	//	base.B ();

	//	base._delegat_e ();
	}
}

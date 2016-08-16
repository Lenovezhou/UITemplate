using UnityEngine;
using System.Collections;

public class testoverride : testabstract {



	void Start ()
	{
		callback ();
		fathersfonction ();

		Debug.LogError (InvokeSigoleton.GetInstance.name);
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

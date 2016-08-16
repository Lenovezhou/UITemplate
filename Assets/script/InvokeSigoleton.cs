using UnityEngine;
using System.Collections;

public class InvokeSigoleton : Singleton<InvokeSigoleton>{
	
	
	public override void Awake ()
	{
		Debug.Log ("itselfAwake____begine");
		base.Awake ();
		Debug.Log ("afterParentAwake");
	}
}

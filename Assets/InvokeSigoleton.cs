using UnityEngine;
using System.Collections;

public class InvokeSigoleton : Singleton<InvokeSigoleton>{

	public override void Awake ()
	{
		base.Awake ();
	}
}

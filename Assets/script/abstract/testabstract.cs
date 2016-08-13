using UnityEngine;
using System.Collections;

public delegate void testdelegate();
public abstract class testabstract : MonoBehaviour {
	public bool a;
	public testdelegate _delegat_e;
	// Use this for initialization
	void Start () {
		Debug.Log ("test myself fonction");

		_delegat_e = fathersfonction;
	}

	public abstract void fathersfonction ();


	// Update is called once per frame
	void Update () {
	
	}
	public void B()
	{
		Debug.Log ("callbackB");
	}
}

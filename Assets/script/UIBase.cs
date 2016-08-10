using UnityEngine;
using System.Collections;

public abstract class UIBase : MonoBehaviour {



	public virtual UImanager.EUI eui
	{
		get{return UImanager.EUI.Num;}
	}

	protected bool bInited;

	void Awake()
	{
		InitComponents ();
		bInited = true;
	}

	protected virtual void InitComponents()
	{
		
	}

	public virtual void OnCloseUI()
	{
		Destroy (this.gameObject);
	}



}
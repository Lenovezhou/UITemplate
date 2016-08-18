using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class UImanager : MonoBehaviour {
	public enum EUI{
		UIlogin,
		Num
	}
	private static Dictionary<EUI,UIBase> duIs=new Dictionary<EUI, UIBase>();
	public static UIBase GetUI(EUI eui)
	{
		if (duIs.ContainsKey(eui)) {
			return duIs [eui];
		}
		return null;
	}
	public static UIBase CreatUI(EUI eui)
	{
		if (duIs.ContainsKey (eui)) {
			if (duIs [eui] != null) {
				return duIs [eui];
			} else {
			
				duIs.Remove (eui);
			}
		} 

		Transform tr = Resources.Load<Transform> ("UI/"+eui);
		Transform uiTr = null;
		if (tr==null) {
			//加载Asset Bundle
		}else{
			uiTr = GameObject.Instantiate (tr)as Transform;
		}
		uiTr.name = eui.ToString ();
		UIBase ui = uiTr.GetComponent<UIBase> ();
		if (ui==null) {
			ui=uiTr.gameObject.AddComponent(Types.GetType(eui.ToString(),typeof(EUI).ToString()))as UIBase;
		}
		ui.transform.localPosition=Vector3.zero;
		duIs.Add(eui,ui);
		return ui;
	}

}

using UnityEngine;
using System.Collections;

public class UStaticFuncs : MonoBehaviour {
	public static Transform FindChild(Transform tr,string childName)
	{
		for (int i = 0; i < tr.childCount; i++) {
			if (tr.GetChild (i).name == childName) {
				Transform t = tr.GetChild (i);
				if (t != null)
				{
					return t;
				}

			} else {
				//查找子的子
				Transform t = FindChild (tr.GetChild (i), childName);
					if (t!=null) {
						return t;
					}
			}
		}
		return null;
	}


	public static T FindChildComponent<T>(Transform tr,string childName)
	{
		Transform t = FindChild (tr, childName);
		return t.GetComponent<T> ();
	}
 

}

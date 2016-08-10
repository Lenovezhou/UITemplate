using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T:Component
{
	private static T Testinstance;
	private static T instance;
	public static T GetInstance
	{
		get	
		{
			if (instance==null) {
				instance = FindObjectOfType<T> ();
				if (instance==null) {
					GameObject obj = new GameObject ();
					obj.name = typeof(T).Name;
					instance = obj.AddComponent<T> ();
				}
			}
			return instance;
		}
	}

	public virtual void Awake()
	{


			if (instance !=  null) {

				Destroy(gameObject);

			}else{

			instance = Testinstance;

				DontDestroyOnLoad(gameObject);

			}

	}
}

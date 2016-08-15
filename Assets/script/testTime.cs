using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class testTime : MonoBehaviour,IDragHandler,IPointerEnterHandler {

	private bool isenter=false;

	public void OnPointerEnter (PointerEventData eventData)
	{
		isenter = true;
	}


	public void OnDrag (PointerEventData eventData)
	{
		float a = Input.GetAxis ("Mouse X")*21f;
		float b = Input.GetAxis ("Mouse Y")*21f;

		GetComponent<RectTransform> ().localPosition += new Vector3 (a,b,0);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}

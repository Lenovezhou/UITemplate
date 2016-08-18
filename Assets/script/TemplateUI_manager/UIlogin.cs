using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIlogin : UIBase {


	public override UImanager.EUI eui
	{
		get{return UImanager.EUI.UIlogin; }
	}

	InputField usernameinput;
	InputField passwordinput;
	Button btnLogin;
	protected override void InitComponents()
	{
		usernameinput = UStaticFuncs.FindChildComponent<InputField> (transform,"username");
		passwordinput = UStaticFuncs.FindChildComponent<InputField> (transform,"username");


		btnLogin.onClick.AddListener(
		delegate() 
			{
				string username=usernameinput.text;
				string password=passwordinput.text;
			}
		
		
		);
	}


}

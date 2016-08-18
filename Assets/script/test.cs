using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public delegate void dele();
	public static dele d_dele=null;
    private Button buttons;
    private GameObject ALL;

    void Start() 
    {
        StartCoroutine(LoadBoundle(d_dele));
        buttons=GetComponent<Button>();
        buttons.onClick.AddListener(Oncklik);
    }

    void Oncklik() 
    {
		Debug.Log (d_dele.ToString());
        d_dele();
    }
    public IEnumerator LoadBoundle(dele tempdele) 
    {
		WWW pic = new WWW ("file://"+Application.dataPath + "/Asset/IMG_0608.png");
		WWW w = new WWW("file://"+Application.dataPath + "/Asset/Cube.assetbundle");
        yield return w;
		yield return pic;
		d_dele += ChangeStates;
        ALL = (GameObject)Instantiate(w.assetBundle.mainAsset);
		Material material = new Material (Shader.Find("Sogoal/HidePart"));
		material.mainTexture = pic.texture;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<RawImage>().texture= pic.texture;
		ALL.GetComponent<MeshRenderer> ().material = material;
        ALL.transform.localPosition = Vector3.zero;

    }
    void ChangeStates() 
    {
		Debug.Log ("Begin change status");
		long l = 0;
		while (l<999) {
			l += 1;
			ALL.transform.rotation = Quaternion.Euler (l,0,0);
		}
        ALL.transform.LookAt(Camera.main.transform.position);
		//ALL.transform.rotation = Quaternion.Euler (10,0,0);
    }
    void OnDisable() 
    {
		buttons.onClick.RemoveAllListeners ();
        d_dele -= ChangeStates;
    }
}

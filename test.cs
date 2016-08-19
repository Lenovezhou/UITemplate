using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public delegate void dele();
    public event dele d_dele;
    private Button buttons;
    private GameObject ALL,N_pic;
    private float a, b,c,d;
    void Start() 
    {
        d_dele += ChangeStates;
        StartCoroutine(LoadBoundle(d_dele));
        buttons=GetComponent<Button>();
        buttons.onClick.AddListener(Oncklik);
    }

    void Oncklik() 
    {
        Debug.Log(d_dele+"d_dele");
        d_dele();
    }
    public IEnumerator LoadBoundle(dele tempdele) 
    {
        WWW pic = new WWW("http://img2.niushe.com/upload/201304/19/14-22-31-71-26144.jpg");
        WWW w = new WWW("file://"+Application.dataPath + "/StreamingAssets/ALL.assetbundle");
        WWW tpic = new WWW("file://" + Application.dataPath + "/Asset/IMG_0608.assetbundle");
        yield return w;
        yield return pic;
        yield return tpic;
        ALL = (GameObject)Instantiate(w.assetBundle.mainAsset);
        ALL.transform.localPosition = Vector3.zero;
        RawImage picraw = GameObject.FindGameObjectWithTag("Player").GetComponent<RawImage>();
        RawImage t_pic = GameObject.FindGameObjectWithTag("Shootable").GetComponent<RawImage>();
        MeshRenderer[] childmesh= ALL.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer item in childmesh)
        {
            item.material.mainTexture = pic.texture;
        }
        UnityEngine.AssetBundle ab = tpic.assetBundle;
        t_pic.texture = (Texture)ab.LoadAsset("IMG_0608");
        picraw.texture = pic.texture;
        a= pic.texture.width;
        b= pic.texture.height;
        c = tpic.texture.width;
        d = tpic.texture.width;
        picraw.GetComponent<RectTransform>().localScale = new Vector3(a/b,1,1);
        t_pic.GetComponent<RectTransform>().localScale = new Vector3(c/d,1,1);
        tempdele += ChangeStates;
    }
    void ChangeStates() 
    {
        ALL.transform.LookAt(Camera.main.transform.position);
        ALL.transform.rotation = Quaternion.Euler(20,0,0);
    }
    void OnDisable() 
    {
        d_dele -= ChangeStates;
    }
}

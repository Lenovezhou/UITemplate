using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {

    public delegate void dele();
    public dele d_dele;
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
        d_dele();
    }
    public IEnumerator LoadBoundle(dele tempdele) 
    {

        WWW w = new WWW(Application.dataPath + "/StreamingAssets/ALL.assetbundle");
        yield return w;
        Debug.LogError(w.error+"downerro"+w.isDone);
        tempdele += ChangeStates;
        ALL = (GameObject)Instantiate(w.assetBundle.mainAsset);
        ALL.transform.localPosition = Vector3.zero;
    }
    void ChangeStates() 
    {
        ALL.transform.LookAt(Camera.main.transform.position);
        float a = 360f;
        while (a > 0) 
        {
            a += 0.1f;
            ALL.transform.eulerAngles = new Vector3(0,a,0);
        }
    }
    void OnDisable() 
    {
        d_dele -= ChangeStates;
    }
}

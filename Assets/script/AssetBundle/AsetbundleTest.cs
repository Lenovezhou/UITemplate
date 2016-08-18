using UnityEngine;
using System.Collections;
using UnityEditor;

public class AsetbundleTest :Editor {
	[MenuItem("Creat/CreateAssetBunldes")]  
	public static void CreateAssetBunldes()  
	{  
		Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);  

		foreach (Object obj in SelectedAsset)  
		{  
			TextureImporter ti = (TextureImporter)TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(obj));  
			ti.textureType = TextureImporterType.GUI;  
			ti.filterMode = FilterMode.Point;  
			ti.textureFormat = TextureImporterFormat.RGBA32;  

			string targetPath = Application.dataPath + "/Asset/" + obj.name + ".png";  
			if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))  
			{  
				Debug.Log(obj.name + "资源打包成功");  
			}  
			else  
			{  
				Debug.Log(obj.name + "资源打包失败");  
			}  
		}  

		AssetDatabase.Refresh();  

	}  
	[MenuItem("Creat/CreateAssetbuildsingoletonBunldes")]  
	public static void CreatesingontonAssetBunldes()  
	{  
		Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);  

		foreach (Object obj in SelectedAsset)  
		{  
			
			string targetPath = Application.dataPath + "/Asset/" + obj.name + ".assetbundle";  
			if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))  
			{  
				Debug.Log(obj.name + "资源打包成功");  
			}  
			else  
			{  
				Debug.Log(obj.name + "资源打包失败");  
			}  
		}  

		AssetDatabase.Refresh();  

	}  


}

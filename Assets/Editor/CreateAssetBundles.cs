
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
    }
}




















// public class CreateAssetBundles : MonoBehaviour
// {
//
//     [MenuItem("Assets/Build Assetbundles")]
//
//     static void BuildAssetBundle()
//     {
//         string AssetBundleDirectory = "Asset/AssetBundle";
//
//         if (!Directory.Exists(AssetBundleDirectory))
//         {
//             Directory.CreateDirectory(AssetBundleDirectory);
//         }
//
//         BuildPipeline.BuildAssetBundles(AssetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }

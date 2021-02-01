using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
 
public class BundleWebLoader : MonoBehaviour
{
    #region Fields

    public string bundleUrl;   // https://drive.google.com/uc?export=download&id=1h5uZP_m1dx8vPotvQm6BSZve7XnNIodi
    public string assetName;   // Box

    #endregion


    #region Coroutine

    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null) {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
            
            //Instantiating the game object, which is downloaded from server
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }
    }

    #endregion
    
 
 
}
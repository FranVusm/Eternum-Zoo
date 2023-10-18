using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class armar_reset : MonoBehaviour
{
    public GameObject arma;
    // Start is called before the first frame update
   
    private void OnApplicationQuit()
    {
        string prefabPath = "Assets/Darael/scene/arma 1.prefab";

        
        PrefabUtility.SaveAsPrefabAsset(arma, prefabPath);
    }
     
}

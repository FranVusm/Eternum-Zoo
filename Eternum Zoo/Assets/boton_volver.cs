using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton_volver : MonoBehaviour
{
    // Start is called before the first frame update
    public BateriaSlot arma;
    public GameObject arma_reset;
    public void CambiarAScena()
    {
        arma = FindAnyObjectByType<BateriaSlot>();
        arma.GuardarPrefabModificado();
        SceneManager.LoadScene("NivelZoo");
        string prefabPath = "Assets/main_juego/Prefrab/intermedio.prefab";


        PrefabUtility.SaveAsPrefabAsset(arma_reset, prefabPath);
    }
}

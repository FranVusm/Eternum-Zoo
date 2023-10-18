using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BateriaSlot : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public KeyCode spawnKey;
    public KeyCode spawnKey2;
    public GameObject spawn;

    [System.Serializable]
    public class SpawnedObjectData
    {
        public Vector3 position;
        public Quaternion rotation;
        public GameObject prefab;
    }

    private List<SpawnedObjectData> spawnedObjectsData = new List<SpawnedObjectData>();

    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            

            Transform hijo = spawn.transform.Find("spawn_1");
            InstanciarYGuardarObjeto(objectToSpawn, hijo, hijo.name);

            Transform hijo2 = spawn.transform.Find("spawn_2");
            InstanciarYGuardarObjeto(objectToSpawn2, hijo2, hijo2.name);

            Transform hijo3 = spawn.transform.Find("spawn_3");
            InstanciarYGuardarObjeto(objectToSpawn3, hijo3, hijo3.name);

            Transform hijo4 = spawn.transform.Find("spawn_4");
            InstanciarYGuardarObjeto(objectToSpawn4, hijo4, hijo4.name);

            GuardarPrefabModificado();
        }
        if (Input.GetKeyDown(spawnKey2)){
            GuardarPrefabModificado();
        }
    }


    public void InstanciarYGuardarObjeto(GameObject objetoPrefab, Transform spawnTransform, string hijo)
    {
        Vector3 spawnPosition = spawnTransform.position;
        Quaternion rotationQuaternion = spawnTransform.rotation;
        GameObject spawnedObject = Instantiate(objetoPrefab, spawnPosition, rotationQuaternion);
        spawnedObject.transform.parent = spawn.transform.Find(hijo);
    }
    

    public void GuardarPrefabModificado()
    {
        string prefabPath = "Assets/Darael/scene/arma 1.prefab";

        // Guardar el objeto spawn como un prefab sin un padre
        // Esto es un comentario
        PrefabUtility.SaveAsPrefabAsset(spawn, prefabPath);
    }

}

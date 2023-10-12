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
    public GameObject spawn;

    [System.Serializable]
    public class SpawnedObjectData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale; // Nueva variable para almacenar la escala
        public GameObject prefab;
    }

    private List<SpawnedObjectData> spawnedObjectsData = new List<SpawnedObjectData>();

    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Vector3 spawnPosition = spawn.transform.position;
            Quaternion rotationQuaternion = spawn.transform.rotation;
            GameObject spawnedObject = Instantiate(spawn, spawnPosition, rotationQuaternion);
            spawnedObject.transform.parent = transform;

            // Guardar datos del objeto padre
            SpawnedObjectData objectDataPadre = new SpawnedObjectData
            {
                position = spawnedObject.transform.position,
                rotation = spawnedObject.transform.rotation,
                scale = spawnedObject.transform.localScale, // Obtén la escala del objeto
                prefab = spawnedObject
            };

            spawnedObjectsData.Add(objectDataPadre);

            //Los demás objetos
            Transform hijo = spawn.transform.Find("spawn_1");
            InstanciarYGuardarObjeto(objectToSpawn, hijo);

            Transform hijo2 = spawn.transform.Find("spawn_2");
            InstanciarYGuardarObjeto(objectToSpawn2, hijo2);

            Transform hijo3 = spawn.transform.Find("spawn_3");
            InstanciarYGuardarObjeto(objectToSpawn3, hijo3);

            Transform hijo4 = spawn.transform.Find("spawn_4");
            InstanciarYGuardarObjeto(objectToSpawn4, hijo4);

            GuardarPrefabModificado();
        }
    }

    private void InstanciarYGuardarObjeto(GameObject objetoPrefab, Transform spawnTransform)
    {
        Vector3 spawnPosition = spawnTransform.position;
        Quaternion rotationQuaternion = spawnTransform.rotation;
        Vector3 scale = spawnTransform.localScale; // Obtén la escala del objeto

        GameObject spawnedObject = Instantiate(objetoPrefab, spawnPosition, rotationQuaternion);
        spawnedObject.transform.localScale = scale; // Aplica la escala al objeto instanciado
        spawnedObject.transform.parent = transform;

        SpawnedObjectData objectData = new SpawnedObjectData
        {
            position = spawnedObject.transform.position,
            rotation = spawnedObject.transform.rotation,
            scale = scale, // Guarda la escala
            prefab = spawnedObject
        };

        spawnedObjectsData.Add(objectData);
    }

    public void GuardarPrefabModificado()
    {
        GameObject prefabParent = new GameObject("ArmaModificada");

        foreach (var data in spawnedObjectsData)
        {
            GameObject spawnedObject = Instantiate(data.prefab, data.position, data.rotation);
            spawnedObject.transform.localScale = data.scale; // Aplica la escala al objeto instanciado
            spawnedObject.transform.parent = prefabParent.transform;
        }

        string prefabPath = "Assets/Darael/scene/armamodificada.prefab";

        PrefabUtility.SaveAsPrefabAssetAndConnect(prefabParent, prefabPath, InteractionMode.UserAction);
        DestroyImmediate(prefabParent);

        spawnedObjectsData.Clear();
    }
}

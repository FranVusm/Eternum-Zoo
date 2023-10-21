using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class BateriaSlot : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public KeyCode spawnKey;
     
    public GameObject spawn;
    private Vector3 posicionInicial;
    [System.Serializable]
    public class SpawnedObjectData
    {
        public Vector3 position;
        public Quaternion rotation;
        public GameObject prefab;
    }

    private List<SpawnedObjectData> spawnedObjectsData = new List<SpawnedObjectData>();
    
    


    public void InstanciarYGuardarObjeto(GameObject objetoPrefab, Transform spawnTransform, string hijo)
    {
        Vector3 spawnPosition = spawnTransform.position;
        Quaternion rotationQuaternion = spawnTransform.rotation;
        GameObject spawnedObject = Instantiate(objetoPrefab, spawnPosition, rotationQuaternion);
        spawnedObject.transform.parent = spawn.transform.Find(hijo);
    }
    
     
     

}

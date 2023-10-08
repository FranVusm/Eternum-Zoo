using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateria_slot : MonoBehaviour
{
    public GameObject objectToSpawn; // El Prefab del objeto que deseas spawnear.
    public KeyCode spawnKey = KeyCode.Space; // La tecla para spawnear el objeto.
    public GameObject spawn;
    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            
            Transform hijo = spawn.transform.Find("spawn");
            // Obtener las coordenadas del objeto desde el cual deseas spawnear.
            Vector3 spawnPosition = hijo.position;
            
            Quaternion rotationQuaternion = hijo.rotation;
            // Spawnear el objeto en las coordenadas específicas.
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, rotationQuaternion);
            print(hijo.rotation);
            // Unir el objeto spawn al objeto inicial.
            spawnedObject.transform.parent = transform;
        }
    }
}

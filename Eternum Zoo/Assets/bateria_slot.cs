using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bateria_slot : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;// El Prefab del objeto que deseas spawnear.
    public KeyCode spawnKey; // La tecla para spawnear el objeto.
    public GameObject spawn;
    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            
            Transform hijo = spawn.transform.Find("spawn_1");
            // Obtener las coordenadas del objeto desde el cual deseas spawnear.
            Vector3 spawnPosition = hijo.position;
            
            Quaternion rotationQuaternion = hijo.rotation;
            // Spawnear el objeto en las coordenadas específicas.
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, rotationQuaternion);
            // Unir el objeto spawn al objeto inicial.
            spawnedObject.transform.parent = transform;

            Transform hijo2 = spawn.transform.Find("spawn_2");
            // Obtener las coordenadas del objeto desde el cual deseas spawnear.
            Vector3 spawnPosition2 = hijo2.position;

            Quaternion rotationQuaternion2 = hijo2.rotation;
            // Spawnear el objeto en las coordenadas específicas.
            GameObject spawnedObject2 = Instantiate(objectToSpawn2, spawnPosition2, rotationQuaternion2);
            // Unir el objeto spawn al objeto inicial.
            spawnedObject2.transform.parent = transform;


            Transform hijo3 = spawn.transform.Find("spawn_3");
            // Obtener las coordenadas del objeto desde el cual deseas spawnear.
            Vector3 spawnPosition3 = hijo3.position;

             
            Quaternion rotationQuaternion3 = hijo3.rotation;
            // Spawnear el objeto en las coordenadas específicas.
            GameObject spawnedObject3 = Instantiate(objectToSpawn3, spawnPosition3, rotationQuaternion3);
            // Unir el objeto spawn al objeto inicial.
            spawnedObject3.transform.parent = transform;

            Transform hijo4 = spawn.transform.Find("spawn_4");
            // Obtener las coordenadas del objeto desde el cual deseas spawnear.
            Vector3 spawnPosition4 = hijo4.position;

            Quaternion rotationQuaternion4 = hijo4.rotation;
            // Spawnear el objeto en las coordenadas específicas.
            GameObject spawnedObject4 = Instantiate(objectToSpawn4, spawnPosition4, rotationQuaternion4);
            // Unir el objeto spawn al objeto inicial.
            spawnedObject4.transform.parent = transform;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn; // Lista de objetos que puedes instanciar
    public Transform[] spawnPoints; // Lista de puntos de spawn
    public float spawnInterval = 5f; // Intervalo de tiempo en segundos entre las instancias

    private void Start()
    {
        // Obtén todos los componentes Transform hijos del objeto padre
        spawnPoints = GetComponentsInChildren<Transform>();

        // Comienza el proceso de spawn
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true) // Esto hará que el spawn se ejecute continuamente
        {

            // Escoge un punto de spawn aleatorio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instancia el objeto en el punto de spawn
            //Debug.Log("Se ha instanciado un enemigo");
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Espera el intervalo de tiempo antes de la próxima instancia
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
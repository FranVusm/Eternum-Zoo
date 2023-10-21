using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn; // Lista de objetos que puedes instanciar
    public Transform[] spawnPoints; // Lista de puntos de spawn
    public float initialSpawnInterval = 5f; // Intervalo de tiempo inicial en segundos entre las instancias
    public float spawnRadius = 2f; // Radio de dispersión para las coordenadas x y z
    public float timeToDecreaseSpawnInterval = 10f; // Tiempo en segundos para disminuir el intervalo de spawn
    public float decreasePercentage = 0.1f; // Porcentaje de disminución del intervalo de spawn

    private float spawnInterval; // Intervalo de tiempo actual entre las instancias

    private void Start()
    {
        // Obtén todos los componentes Transform hijos del objeto padre
        spawnPoints = GetComponentsInChildren<Transform>();
        spawnInterval = initialSpawnInterval;

        // Comienza el proceso de spawn
        StartCoroutine(SpawnObjects());
        StartCoroutine(DecreaseSpawnInterval());
    }

    IEnumerator SpawnObjects()
    {
        while (true) // Esto hará que el spawn se ejecute continuamente
        {
            // Escoge un punto de spawn aleatorio
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Calcula un offset aleatorio en las coordenadas x y z dentro del radio de dispersión
            Vector3 spawnOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0f, Random.Range(-spawnRadius, spawnRadius));

            // Instancia el objeto en el punto de spawn con el offset aleatorio
            Instantiate(objectToSpawn, spawnPoint.position + spawnOffset, spawnPoint.rotation);

            // Espera el intervalo de tiempo antes de la próxima instancia
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator DecreaseSpawnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToDecreaseSpawnInterval);
            spawnInterval -= spawnInterval * decreasePercentage;
            
            // Limita el spawnInterval al valor mínimo
            spawnInterval = Mathf.Max(spawnInterval, 0.1f);
        }
    }
}
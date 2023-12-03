using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo_doble_alien : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce;
    public float timeBetweenShooting, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    private Rigidbody playerRb;
    public float recoilForce;
    public GameObject muzzleFlash;
    public Transform[] bulletSpawnPoints; // Puntos de spawn de las balas
    public Candado inicio;
    public int bulletsLeft, bulletsShot;
    bool readyToShoot, reloading;
    bool allowInvoke = true;
    public float distanciaMinima = 1f;
    public float distanciaMaxima = 50f;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;

        GameObject playerObject = GameObject.Find("player");
        if (playerObject != null)
        {
            playerRb = playerObject.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el nombre 'player' en la escena.");
        }
    }

    private void Update()
    {
        inicio = FindAnyObjectByType<Candado>();
        if (inicio.inicia)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, playerRb.position);

            // Comprobar si el NPC está dentro del rango de disparo
            if (distanciaAlJugador >= distanciaMinima && distanciaAlJugador <= distanciaMaxima)
            {
                // Apuntar hacia el jugador
                Vector3 directionToPlayer = (playerRb.position - bulletSpawnPoints[0].position).normalized;
                transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

                MyInput();
            }
        }
        // Calcular la distancia al jugador
    }

    private void MyInput()
    {
        // NPC siempre está listo para disparar, no hay necesidad de entrada del jugador

        // Shooting
        if (readyToShoot && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();

            // Revisa si hay balas restantes antes de invocar nuevamente
            if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            {
                Invoke("MyInput", timeBetweenShots); // Invoca la función para el próximo disparo
            }
            else
            {
                // Todas las balas han sido disparadas o no hay balas restantes, permite la invocación de ResetShot
                allowInvoke = true;
            }
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        for (int i = 0; i < bulletSpawnPoints.Length; i++)
        {
            // Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(bullet, bulletSpawnPoints[i].position, Quaternion.identity);

            // Calculate direction towards the player
            Vector3 directionToPlayer = (playerRb.position - bulletSpawnPoints[i].position).normalized;
            currentBullet.transform.rotation = Quaternion.LookRotation(directionToPlayer);

            // Add forces to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionToPlayer * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.up * upwardForce, ForceMode.Impulse);

            if (muzzleFlash != null)
                Instantiate(muzzleFlash, bulletSpawnPoints[i].position, Quaternion.identity);

            bulletsLeft--;
            bulletsShot++;

            Debug.Log("Estoy disparando");

            if (allowInvoke)
            {
                Invoke("ResetShot", timeBetweenShooting);
                allowInvoke = false;

                playerRb.AddForce(-directionToPlayer * recoilForce, ForceMode.Impulse);
            }
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}

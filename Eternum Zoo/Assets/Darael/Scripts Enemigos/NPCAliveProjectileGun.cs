using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAliveProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce, upwardForce;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    private Rigidbody playerRb;
    public float recoilForce;
    public GameObject muzzleFlash;
    public float distanciaMinima = 10f;
    public float distanciaMaxima = 50f;
    public Transform bulletSpawnPoint; // Punto de spawn de las balas

    int bulletsLeft, bulletsShot;
    bool readyToShoot, reloading;
    bool allowInvoke = true;

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
        // Calcular la distancia al jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, playerRb.position);

        // Comprobar si el NPC está dentro del rango de disparo
        if (distanciaAlJugador >= distanciaMinima && distanciaAlJugador <= distanciaMaxima)
        {
            // Apuntar hacia el jugador
            Vector3 directionToPlayer = (playerRb.position - bulletSpawnPoint.position).normalized;
            transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            MyInput();
        }
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

        // Calculate direction with spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 directionWithSpread = transform.forward + new Vector3(x, y, 0);

        // Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;

        // Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce, ForceMode.Impulse);

        if (muzzleFlash != null)
            Instantiate(muzzleFlash, transform.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}

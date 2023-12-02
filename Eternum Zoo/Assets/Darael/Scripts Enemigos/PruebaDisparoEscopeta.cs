using UnityEngine;
using TMPro;
using System;
using System.Threading;

/// Thanks for downloading my projectile gun script! :D
/// Feel free to use it in any project you like!
/// 
/// The code is fully commented but if you still have any questions
/// don't hesitate to write a yt comment
/// or use the #coding-problems channel of my discord server
/// 
/// Dave
public class PruebaDisparoEscopeta : MonoBehaviour
{
    //bullet 
    public GameObject bullet;
    public GameObject arma_detalles;
    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    private float timeBetweenShooting = 0.7f, spread = 0.5f, reloadTime = 1.5f, timeBetweenShots = 0.7f;

    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }
    private bool uno = true;
    private bool dos = true;
    private bool tres = true;
    private bool cuatro = true;
    private bool cinco = true;
    private void Update()
    {
        MyInput();
        
        
        Transform hijo = arma_detalles.transform.Find("spawnesco_1");
        if (hijo.childCount > 0 && uno)
        {
            Transform hijo12 = hijo.GetChild(0);
            mejora_nombre(hijo12.name);
            uno = false;
            print(uno);
        }

        Transform hijo2 = arma_detalles.transform.Find("arreglo_1");
        if (hijo2.childCount > 0  && dos)
        {
            Transform hijo22 = hijo2.GetChild(0);
            mejora_nombre(hijo22.name);
            dos = false;
            print(dos);
        }
        Transform hijo3 = arma_detalles.transform.Find("arreglo_3");
        if (hijo3.childCount > 0 && tres)
        {
            Transform hijo31 = hijo3.GetChild(0);
            mejora_nombre(hijo31.name);
            tres = false;
            print(tres);
        }
        Transform hijo4 = arma_detalles.transform.Find("arreglo_3");
        if (hijo4.childCount > 0 && cuatro)
        {
            Transform hijo42 = hijo4.GetChild(0);
            mejora_nombre(hijo42.name);
            cuatro = false; 
        }
        Transform hijo5 = arma_detalles.transform.Find("arreglo_4");
        if (hijo5.childCount > 0 && cinco)
        {
            Transform hijo52 = hijo5.GetChild(0);
            mejora_nombre(hijo52.name);
            cinco = false;
        }
        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);

    }
    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
            //Debug.Log("Se ha disparado");
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        for (int i = 0; i < bulletsPerTap; i++)
        {
            // Calculate spread for each bullet
            float spreadX = UnityEngine.Random.Range(-spread * 2, spread * 2);
            float spreadY = UnityEngine.Random.Range(-spread * 2, spread * 2);

            // Calculate new direction with individual bullet spreads
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(spreadX, spreadY, 0);

            // Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
            currentBullet.transform.forward = directionWithSpread.normalized;

            // Add forces to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

            // Instantiate muzzle flash, if available
            if (muzzleFlash != null)
                Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

            bulletsLeft--;
            bulletsShot++;

            // Add recoil to player for each bullet
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }

        // Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

        // Debug.Log("Disparo");
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }

    

    private void mejora_nombre(string nombre)
    {
        if (nombre == "balas_reserva(Clone)"  )
        {
            
            magazineSize += 5;
        }
        if (nombre == "bateria_esco(Clone)")
        {
            timeBetweenShooting = 0.1f;
            timeBetweenShots = 0.1f;
            reloadTime = 0.5f;
        }
    }
}

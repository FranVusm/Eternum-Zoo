
using UnityEngine;
using TMPro;
using System;

/// Thanks for downloading my projectile gun script! :D
/// Feel free to use it in any project you like!
/// 
/// The code is fully commented but if you still have any questions
/// don't hesitate to write a yt comment
/// or use the #coding-problems channel of my discord server
/// 
/// Dave
public class ProjectileGunTutorial : MonoBehaviour
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

    private void Update()
    {
        MyInput();

        Transform hijo = arma_detalles.transform.Find("spawn_1");
        if (hijo.childCount > 0)
        {
           Transform hijo2 =  hijo.GetChild(0);
            mejora_nombre(hijo2.name);
             
        }
        Transform hijo22 = arma_detalles.transform.Find("spawn_2");
        if (hijo22.childCount > 0)
        {
            Transform hijo23 = hijo22.GetChild(0);
            mejora_nombre(hijo23.name);

        }
        Transform hijo3 = arma_detalles.transform.Find("spawn_3");
        if (hijo3.childCount > 0)
        {
            Transform hijo31 = hijo3.GetChild(0);
            mejora_nombre(hijo31.name);

        }
        Transform hijo4 = arma_detalles.transform.Find("spawn_4");
        if (hijo4.childCount > 0)
        {
            Transform hijo41 = hijo4.GetChild(0);
            mejora_nombre(hijo41.name);

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

        //Calculate spread
        float x = UnityEngine.Random.Range(-spread, spread);
        float y = UnityEngine.Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
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
      if(nombre == "bateria(Clone)")
        {
            timeBetweenShooting = 0.1f;
            timeBetweenShots = 0.1f;
        }
        if (nombre == "cargador(Clone)")
        {
            magazineSize = 30;
        }
        if (nombre == "cooler(Clone)")
        {
            reloadTime = 0.5f;
        }
        if (nombre == "silenciador(Clone)")
        {
            spread = 0f;
        }
    }
}

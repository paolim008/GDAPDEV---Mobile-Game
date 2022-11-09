using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProjectileGun : MonoBehaviour
{
    //Bullet
    public GameObject bullet;
    [SerializeField] private GameObject[] ammo;

    //Force
    public float shootForce, upwardForce;

    //Gun Stats
    public float timeBetweenShooting, timeBetweenShots, spread, reloadTime;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    private int bulletsLeft, bulletsShot;

    //Reload Animation
    //[SerializeField] private GameObject reloadScript;

    //bools
    private bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //Troubleshooting
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full;
        bulletsLeft = magazineSize;
        readyToShoot = true;

        
    }

    private void Update()
    {
        //Muzzle Flash Position
        Vector3 muzzFlashPos = new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z + 4 );

        MyInput();

        //Set ammo display if it exists;
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft/bulletsPerTap + "/" + magazineSize/bulletsPerTap);


    }

    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        /*
        if (allowButtonHold) 
            shooting = Input.GetKey(KeyCode.Mouse0);
        else 
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        */

        //Reloading
        if(PlayerActions.Instance.IsReloading() && bulletsLeft < magazineSize && bulletsLeft < magazineSize && !reloading) Reload();
        //Force Reload
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();


        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        //Find the exact hit using a raycast

        //Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(mouseX, mouseY, 0f));
        RaycastHit hit;
        
        //Rotate Gun
       //this.GetComponent<Transform>().transform.LookAt(ray.origin);

        //check if ray hits
        Vector3 targetPoint = ray.GetPoint(5f);

        //Calculate direction from attackPoint to targetPoint

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

            //Calculate spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            float z = Random.Range(-spread, spread);

        //Calculate new Direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, z);



        //Instantiate Bullet/Projectile
         GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
                currentBullet.transform.forward = directionWithSpread.normalized;




                //Add Forces
                currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
                currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

                //Instantiates muzzle flash if you have one on
                if (muzzleFlash != null)
                    Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


                bulletsLeft--;
                bulletsShot++;

                //Invoke resetShot function
                if (allowInvoke)
                {
                    Invoke("ResetShot", timeBetweenShooting);
                    allowInvoke = false;

                    ////Add recoil
                    //playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
                //Multiple bullets per tap
                if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
                    Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //Rotate Gun
        //this.GetComponent<Transform>().rotation = Quaternion.identity;
        //Allowing shooting and invoking
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        this.GetComponent<Transform>().rotation = Quaternion.Euler(-45, 0, 0);
        //reloadScript.SetActive(true);


        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        bulletsLeft = magazineSize;
        reloading = false;
    }

    public float GetReloadTime()
    {
        return reloadTime;
    }
}



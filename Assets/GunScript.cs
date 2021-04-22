using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunScript : MonoBehaviour
{
    //action ref
    public SteamVR_Action_Boolean FireShot;

    //hand ref
    public SteamVR_Input_Sources handType;

    //reference to Object
    public GameObject Gun;
    

    //other vars
    public float damage = 10f;
    public float fireRate = 15f;
    public float range = 100f;
    public float impactForce = 30f;
    

    public Camera gunTip;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public GameObject impaceOnStone;

    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        FireShot.AddOnStateDownListener(TriggerDown, handType);
        FireShot.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource){
        //Debug.Log("Trigger is Up");
        Gun.GetComponent<MeshRenderer>().enabled = true;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger is Down");
        //Gun.GetComponent<MeshRenderer>().enabled = false;
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        
        if (Physics.Raycast(gunTip.transform.position, gunTip.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Gun.GetComponent<MeshRenderer>().enabled = false;
            
            Target target = hit.transform.GetComponent<Target>();
            if (target != null){
                target.takeDamage(damage);
            }

            ShipScript ship = hit.transform.GetComponent<ShipScript>();
            if (ship != null){
                ship.damageShip(damage);
            }

            // isStoneMat stoneTarget = hit.transform.GetComponent<isStoneMat>();
            // if (stoneTarget != null){
            //     GameObject stoneImpactGO = Instantiate(impaceOnStone, hit.point, Quaternion.LookRotation(hit.normal));
            //     Destroy(stoneImpactGO, 5f);
            // }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }


            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}

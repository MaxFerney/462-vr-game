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
    public float range = 100f;

    public Camera gunTip;
    // Start is called before the first frame update
    void Start()
    {
        FireShot.AddOnStateDownListener(TriggerDown, handType);
        FireShot.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource){
        Debug.Log("Trigger is Up");
        Gun.GetComponent<MeshRenderer>().enabled = true;
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is Down");
        //Gun.GetComponent<MeshRenderer>().enabled = false;
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(gunTip.transform.position, gunTip.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Gun.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

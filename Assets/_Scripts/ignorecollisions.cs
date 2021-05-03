using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ignorecollisions : MonoBehaviour
{
    //public GameObject baseObject;
    public GameObject[] exclusions;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < exclusions.Length; i++)
        {
            var colliderComponent = exclusions[i].GetComponent<Collider>();

            if(colliderComponent!=null)
            {
                Physics.IgnoreCollision(colliderComponent, GetComponent<Collider>());
            }
            else
            {
                Debug.Log("No valid components on ["+exclusions[i]+"]");
            }
            
        }
        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{
    public Transform Player;
    public Transform Ship;

    int MoveSpeed = 1;
    int MinDist = 2;

    void Start()
    {

    }

    void Update()
    {

        if (Vector3.Distance(transform.position, Player.position) <= Vector3.Distance(transform.position, Ship.position))
        {
            transform.LookAt(Player);

            if (Vector3.Distance(transform.position, Player.position) <= MinDist)
            {
                Debug.Log("Damaging Player");
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
                //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            else
            {
                Debug.Log("No Damage");
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }

        }
        else
        {
            transform.LookAt(Ship);

            if (Vector3.Distance(transform.position, Ship.position) <= MinDist)
            {
                Debug.Log("Damaging Ship"); 
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
                //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            else
            {
                Debug.Log("No Damage");
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
        }
    }
}
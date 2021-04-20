using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{
    public Transform Player;
    public Transform Ship;

    int MoveSpeed = 4;
    int MinDist = 5;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= Vector3.Distance(transform.position, Ship.position))
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MinDist)
            {
                Debug.Log("Damaging Player");
            }
            else
            {
                Debug.Log("No Damage");
            }

        }
        else
        {
            transform.LookAt(Ship);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Ship.position) <= MinDist)
            {
                Debug.Log("Damaging Ship");
            }
            else
            {
                Debug.Log("No Damage");
            }
        }
    }
}
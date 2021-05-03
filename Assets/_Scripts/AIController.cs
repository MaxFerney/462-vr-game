using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIController : MonoBehaviour
{
    public Transform Player;
    public GameObject ShipObject;
    private Transform Ship;

    public int MoveSpeed = 1;
    public int AttackDistance = 2;

    void Start()
    {
        Ship = ShipObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Ship != null)
        {
            if (Vector3.Distance(transform.position, Player.position) <= Vector3.Distance(transform.position, Ship.position))
            {
                transform.LookAt(Player);

                if (Vector3.Distance(transform.position, Player.position) <= AttackDistance)
                {
                    //Debug.Log("Damaging Player");
                    
                    //GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                else
                {
                    //Debug.Log("No Damage");
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }

            }
            else
            {
                transform.LookAt(Ship);

                if (Vector3.Distance(transform.position, Ship.position) <= AttackDistance)
                {
                    //Debug.Log("Damaging Ship"); 
                    if (Ship.gameObject != null)
                    {
                        ShipScript ShipData = Ship.GetComponent<ShipScript>();
                        if (ShipData.isAlive())
                        {
                            ShipData.damageShip(2);
                        }
                        
                    }
                    
                    //GetComponent<Rigidbody>().velocity = Vector3.zero;
                    //GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                else
                {
                    //Debug.Log("No Damage");
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }
            }
        }
    }
}
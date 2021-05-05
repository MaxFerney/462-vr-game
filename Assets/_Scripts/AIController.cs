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
    public float Damage = 2f;
    private float CurrentDamage;
    private bool CoolingDown = false;
    public float AttackCooldown = 1f;
    public int AttackDistance = 5;
    


    void Start()
    {
        Ship = ShipObject.GetComponent<Transform>();
        CurrentDamage = Damage;
    }
    
    void Update()
    {
        if (Ship != null)
        {
            if (Vector3.Distance(transform.position, Player.position) <= Vector3.Distance(transform.position, Ship.position))
            {
                transform.LookAt(Player);

                if (Vector3.Distance(transform.position, Player.position) <= AttackDistance/2)
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
                        if (ShipData.isAlive() && !CoolingDown)
                        {
                            ShipData.damageShip(CurrentDamage);
                            Debug.Log("Damaged Ship for "+CurrentDamage+" Damage!");
                            StartCoroutine(JustAttacked());
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
    IEnumerator JustAttacked()
    {
        CurrentDamage = 0f;
        CoolingDown = true;
        Debug.Log("Waiting to Attack...");
        yield return new WaitForSeconds(AttackCooldown);
        Debug.Log("Ready to Attack!!!");
        CurrentDamage = Damage;
        CoolingDown = false;
    }
}
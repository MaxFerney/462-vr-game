using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    
    public float MaxHealth = 100f;
    private float health;
    private float moveConstant;
    //currently this isnt doing anything.
    //public GameObject ShipMesh;

    public Transform ShipSpawnPoint;
    public GameObject Ship;
    public Transform FallPos;
    public GameObject ShipDeathObject;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        moveConstant = FallPos.position.z-ShipSpawnPoint.position.z;
    }
    public void damageShip (float amount)
    {
        health -= amount;
        // doing MaxHealth in case health is added back to ship.
        var newZ = ( 1f - (health/MaxHealth)) * moveConstant ; //moves ship based on health and relative to fall position.
        //Debug.Log(newZ);
        if (health <= 0f)
        {
            Die();
        }
        else
        {
            var dividedZ = (ShipSpawnPoint.position.z + newZ);
            //Debug.Log(dividedZ);
            Ship.transform.position = new Vector3(ShipSpawnPoint.position.x, ShipSpawnPoint.position.y, dividedZ );
        }
    }
    void Die()
    {
        //destroy original object
        Destroy(Ship);

        //show dead ship mesh
        MeshRenderer DeadShipMesh = ShipDeathObject.GetComponent<MeshRenderer>();
        DeadShipMesh.enabled = true;

        //show parts of dead ship (turn child object on, and their subObjects)
        helperScripts.SetActiveAllChildren(ShipDeathObject.transform, true);
        //Destroy(ShipMesh);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public float MaxMoveDistance = 10f;
    public float MaxHealth = 100f;
    private float health;
    //public GameObject ShipToTransform;
    public GameObject ShipMesh;

    public Transform ShipSpawnPoint;
    public Transform ShipPos;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }
    public void damageShip (float amount)
    {
        health -= amount;
        var newZ = (MaxHealth - health) * (1f / MaxMoveDistance) ; //0-10 (max move distance)
        
        if (health <= 0f)
        {
            Die();
        }
        else
        {
            ShipPos.position = new Vector3(ShipSpawnPoint.position.x, ShipSpawnPoint.position.y, (ShipSpawnPoint.position.z + newZ) );
        }
    }
    void Die()
    {
        ShipPos.position = new Vector3(ShipPos.position.x, ShipPos.position.y, ShipSpawnPoint.position.z + MaxMoveDistance);
        //Destroy(ShipMesh);
    }
}

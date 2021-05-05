using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GameObject StandardGolem;
    public Transform[] SpawnPoints;

    void Start()
    {
        //this.myObject = gameObject;
    }

    public void takeDamage (float amount)
    {
        health -= amount;
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        var thisObject = gameObject;
        AIController isGolem = thisObject.transform.GetComponent<AIController>();
        if (isGolem != null)
        {
            spawnController.KillOneSpawnMore(thisObject, SpawnPoints);
        }
        Destroy(gameObject); 
    }
}
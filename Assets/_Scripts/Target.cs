using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private float currentHealth;

    public GameObject StandardGolem;
    public Transform[] SpawnPoints;

    private GameObject SpawningControllerObject;
    private spawnController SpawningController;

    void Start()
    {
        SpawningControllerObject = GameObject.Find("spawn controller");
        SpawningController = SpawningControllerObject.GetComponent<spawnController>();
        currentHealth = health;
    }

    public void takeDamage (float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0f)
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
            SpawningController.KillOneSpawnMore(thisObject, SpawnPoints);
        }
        Destroy(thisObject); 
        Debug.Log("I've been destroyed!");
    }
}
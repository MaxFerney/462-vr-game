using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonScript : MonoBehaviour
{
    public Transform player;
    public Transform newSpawn;
    public GameObject gunObject;

    public GameObject StandardGolem;
    public Transform[] SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameFromMenu()
    {
        player.position = new Vector3(newSpawn.position.x, newSpawn.position.y, newSpawn.position.z);
        //player.rotation = newSpawn.rotation;
        //player.localScale = newSpawn.localScale;
        gunObject.SetActive(true);

        spawnController.SpawnNewEnemy(StandardGolem, SpawnPoints);
    }
}

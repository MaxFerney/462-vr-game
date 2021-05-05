using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class StartGameButtonScript : MonoBehaviour
{
    public Transform player;
    public Transform newSpawn;
    public GameObject gunObject;

    public GameObject StandardGolem;
    public Transform[] SpawnPoints;

    async public void StartGameFromMenu()
    {
        player.position = new Vector3(newSpawn.position.x, newSpawn.position.y, newSpawn.position.z);

        gunObject.SetActive(true);
        for (var i = 0; i < 1; i++)
        {
            spawnController.SpawnNewEnemy(StandardGolem, SpawnPoints);
            await Task.Delay(1000);
        }
    }
}

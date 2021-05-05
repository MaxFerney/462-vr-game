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
            if(SpawnPoints.Length > 0)
            {
                GameObject NewGolem = Instantiate(StandardGolem, SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
                Target TargetInfo = NewGolem.GetComponent<Target>();
                if(TargetInfo != null)
                {
                    TargetInfo.SpawnPoints = SpawnPoints;
                    TargetInfo.StandardGolem = StandardGolem;
                }
                
            }
            await Task.Delay(1000);
        }
    }
}

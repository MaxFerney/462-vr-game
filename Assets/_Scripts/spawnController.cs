using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class spawnController : MonoBehaviour
{
    
    //public int maxEnemies = 10;
    //private float spawnCooldown = 1f;
    //private bool canSpawn = true;
    //public int currentEnemyAmount = 0;

    //private List<GameObject> CurrentEnemyObjects = new List<GameObject>();

    //public int getCurrentEnemyAmount(){return currentEnemyAmount;}
    //public void enemyDie(){currentEnemyAmount-=1;}
    //public List<GameObject> getCurrentEnemyObjects(){return CurrentEnemyObjects;}

    public static void SpawnNewEnemy(GameObject StandardGolem, Transform[] SpawnPoints)
    {
        if(SpawnPoints.Length > 0)
        {
            Instantiate(Resources.Load("BasicGolem"), SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
        }
    }

    public async static void KillOneSpawnMore(GameObject NewObject, Transform[] SpawnPoints, int numToSpawn=2, int msDelay=1000)
    {
        for (var i = 0; i < numToSpawn; i++)
        {
            SpawnNewEnemy(NewObject, SpawnPoints);
            await Task.Delay(msDelay);
        }
    }
    //public static IEnumerator SpawnCooldown()
    //{
    //    canSpawn = false;
    //    yield return new WaitForSeconds(spawnCooldown);
    //    canSpawn = true;
    //}
}

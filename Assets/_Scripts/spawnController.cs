using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        var canSpawn = true;
        if (canSpawn)
        {
            if(SpawnPoints.Length > 0)
            {
                GameObject newEnemy = Instantiate(StandardGolem, SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
            }
        }
    }

    //public static IEnumerator SpawnCooldown()
    //{
    //    canSpawn = false;
    //    yield return new WaitForSeconds(spawnCooldown);
    //    canSpawn = true;
    //}
}

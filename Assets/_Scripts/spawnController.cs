using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class spawnController : MonoBehaviour
{
    
    //public int maxEnemies = 10;
    //private float spawnCooldown = 1f;
    private bool canSpawn = true;
    //public int currentEnemyAmount = 0;

    //private List<GameObject> CurrentEnemyObjects = new List<GameObject>();

    //public int getCurrentEnemyAmount(){return currentEnemyAmount;}
    //public void enemyDie(){currentEnemyAmount-=1;}
    //public List<GameObject> getCurrentEnemyObjects(){return CurrentEnemyObjects;}

    public void SpawnNewEnemy(GameObject StandardGolem, Transform[] SpawnPoints)
    {
        //Resources.Load("BasicGolem")
        if(SpawnPoints.Length > 0)
        {
            GameObject NewGolem = Instantiate(StandardGolem, SpawnPoints[Random.Range(0, SpawnPoints.Length)]);
            Target TargetInfo = NewGolem.GetComponent<Target>();
            if(TargetInfo != null)
            {
                TargetInfo.SpawnPoints = SpawnPoints;
                TargetInfo.StandardGolem = StandardGolem;
                TargetInfo.health = 50f;
            }
            
        }
    }

    public void KillOneSpawnMore(GameObject NewObject, Transform[] SpawnPoints, int numToSpawn=2)
    {
        for (var i = 0; i < numToSpawn; i++)
        {
            
            SpawnNewEnemy(NewObject, SpawnPoints);
            //StartCoroutine(SpawnCooldown(cooldown));
            
            
        }
    }
    // IEnumerator SpawnCooldown(float cooldown)
    // {
    //    canSpawn = false;
    //    yield return new WaitForSeconds(cooldown);
    //    canSpawn = true;
    // }
}

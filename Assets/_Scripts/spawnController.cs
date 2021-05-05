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

    public void SpawnNewEnemy(GameObject StandardGolem, Transform[] SpawnPoints, float newHealth=10f)
    {
        //Resources.Load("BasicGolem")
        if(SpawnPoints.Length > 0)
        {
            Transform newSpawnTransform = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            //Vector3 newspawnpos = newSpawnTransform.position;
            //Vector3 spawnpos = new Vector3(newSpawnTransform.position.x, newSpawnTransform.position.y, newSpawnTransform.position.z);
            GameObject NewGolem = Instantiate( StandardGolem, newSpawnTransform.position, newSpawnTransform.rotation);
            Target TargetInfo = NewGolem.GetComponent<Target>();
            if(TargetInfo != null)
            {
                TargetInfo.SpawnPoints = SpawnPoints;
                TargetInfo.StandardGolem = StandardGolem;
                if (newHealth >= 10f)
                {
                    TargetInfo.health = newHealth;
                }
                else
                {
                    TargetInfo.health=10f;
                }
                
                
            }
            
        }
    }

    public void KillOneSpawnMore(GameObject NewObject, Transform[] SpawnPoints, int numToSpawn=2, float newHealth=10f)
    {
        for (var i = 0; i < numToSpawn; i++)
        {
            
            SpawnNewEnemy(NewObject, SpawnPoints, newHealth);
            //Debug.Log(SpawnPoints[0]);
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

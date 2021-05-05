using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnController : MonoBehaviour
{
    public GameObject StandardGolem;
    public Transform[] SpawnPoints;
    public int maxEnemies = 10;
    public float spawnCooldown = 1f;
    private bool canSpawn = true;
    public int currentEnemyAmount = 0;
    //private List<GameObject> CurrentEnemyObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getCurrentEnemyAmount(){return currentEnemyAmount;}
    public void enemyDie(){currentEnemyAmount-=1;}
    //public List<GameObject> getCurrentEnemyObjects(){return CurrentEnemyObjects;}
    public void SpawnNewEnemy(GameObject enemyObject, Transform SpawnPoint = null)
    {
        if (canSpawn)
        {
            if(SpawnPoint==null && SpawnPoints.Length > 0)
            {
                SpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            }
            GameObject newEnemy = Instantiate(enemyObject, SpawnPoint);
            currentEnemyAmount += 1;
            StartCoroutine(SpawnCooldown());
        }
    }
    IEnumerator SpawnCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true;
    }
}

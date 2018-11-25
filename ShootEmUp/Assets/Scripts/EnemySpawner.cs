using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<Transform> allSpawns = new List<Transform>();
    public GameObject standardEnemy;
    public float cdToSpawn = 1.5f;

    ObjectPool standardEnemyPool = new ObjectPool();
    CountdownScript spawnCD; 
    int rando;

    private void Start()
    {
        standardEnemyPool.StartUpThePool(15, standardEnemy);
        spawnCD = new CountdownScript(cdToSpawn, cdToSpawn, 0.002f, 0.002f);
    }

    private void Update()
    {
        spawnCD.DoAction(EncapsulateSpawn);
    }

    void EncapsulateSpawn()
    {
        SpawnAllSortOfEnemies(standardEnemyPool.allObjs, allSpawns, standardEnemyPool);
    }

    void SpawnAllSortOfEnemies(List<GameObject> tObs, List<Transform> spawnPoints, ObjectPool mPool)
    {
        for (int i = 0; i < tObs.Count; i++)
        {
            if(!tObs[i].activeInHierarchy)
            {
                rando = Random.Range(0, spawnPoints.Count);
                tObs[i].SetActive(true);

                if (!IsPosEmpty(spawnPoints[rando].transform.position,mPool))
                {
                    rando = (rando < spawnPoints.Count - 1) ? rando + 1 : rando - 1;

                    mPool.allObjs[i].SetActive(true);
                    
                    mPool.allObjs[i].transform.position = spawnPoints[rando].transform.position;
                    print("new pos is at " + rando);

                }
                else
                {
                    mPool.allObjs[i].SetActive(true);
                    mPool.allObjs[i].transform.position = spawnPoints[rando].transform.position;
                    print("initial position is at " + rando);
                }

                break;

            }
        }
    }

    bool IsPosEmpty(Vector3 targetPos, ObjectPool thePool)
    {
        foreach (var n in thePool.allObjs)
        {
            if (n.transform.position == targetPos)
            {
                print("returned negative");
                return false;
            }
        }
        print("returned positive");
        return true;
    }
}

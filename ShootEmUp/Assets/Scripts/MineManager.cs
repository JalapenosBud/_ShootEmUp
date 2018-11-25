using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MineManager : MonoBehaviour {

    public Transform mineTankerSpawnPos;

    public GameObject mineTanker;
    public GameObject mine;

    public static MineManager instance;
    public List<Transform> minePositions = new List<Transform>();

    ObjectPool mineTankerPool = new ObjectPool();
    ObjectPool minePool = new ObjectPool();

    CountdownScript cd;
    CountdownScript theMineCD;
    Vector3 distToMine;
    int rando = 0;
    private void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        cd = new CountdownScript(3f, 3f, 0.002f, 0.002f);
        mineTankerPool.StartUpThePool(10, mineTanker);
        minePool.StartUpThePool(20, mine);
        theMineCD = new CountdownScript(1f, 1f, 0.02f, 0.02f);
        //minePositions = FindObjectsOfType<Transform>().OrderBy(x => x.transform.position.y).ToList();
    }
	
	void Update ()
    {
        cd.DoAction(SpawnMineTanker);
        MoveMineTanker();
        //for (int i = 0; i < minePool.allObjs.Count; i++)
        //{
        //    if(minePool.allObjs[i].activeInHierarchy)
        //    {
        //        if(!cd.IsOnCoolDown)
        //        {
        //            if(!randomCD.IsOnCoolDown)
        //            {
        //                rando = Random.Range(0, minePool.allObjs.Count);
        //                randomCD.Start(3f);
        //            }
        //            distToMine = Vector2.Distance(mineTankers[i].transform.position, minePositions[rando].transform.position);

        //            mineTankers[0].transform.position = mineTankerSpawnPos.position;
        //            mineTankers[0].rb2d.velocity = new Vector2(distToMine, distToMine) * mineTankers[i].flySpeed;
        //            cd.Start(3f);
        //            break;
        //        }
                
        //    }
        //}
	}

    public void SpawnMineTanker()
    {
        for (int i = 0; i < mineTankerPool.allObjs.Count; i++)
        {
            if (!mineTankerPool.allObjs[i].activeInHierarchy)
            {
                rando = Random.Range(0, minePositions.Count);
                
                

                
                mineTankerPool.allObjs[i].transform.position = mineTankerSpawnPos.position;
                if(!IsPosEmpty(minePositions[rando].transform.position))
                {
                    rando = (rando < minePositions.Count - 1) ? rando + 1 : rando - 1;
                    
                    mineTankerPool.allObjs[i].SetActive(true);
                    var newDistToMine = (minePositions[rando].transform.position - mineTankerSpawnPos.transform.position);
                    mineTankerPool.allObjs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(newDistToMine.x, newDistToMine.y);
                    print("new pos is at " + rando);
                    
                }
                else
                {
                    mineTankerPool.allObjs[i].SetActive(true);
                    //distance is from the minetanker that spawns to mineposition at a random int's position
                    distToMine = (minePositions[rando].transform.position - mineTankerSpawnPos.transform.position);
                    mineTankerPool.allObjs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(distToMine.x, distToMine.y);
                    print("initial position is at " + rando);
                }
                
                break;
            }
        }
    }

    bool IsPosEmpty(Vector3 targetPos)
    {
        foreach (var n in mineTankerPool.allObjs)
        {
            if(n.transform.position == targetPos)
            {
                print("returned negative");
                return false;
            }
        }
        print("returned positive");
        return true;
    }

    public void MoveMineTanker()
    {
        for (int i = 0; i < mineTankerPool.allObjs.Count; i++)
        {
            if(mineTankerPool.allObjs[i].activeInHierarchy)
            {
                
                
                if(mineTankerPool.allObjs[i].transform.position == minePositions[rando].position)
                {
                    mineTankerPool.allObjs[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    
                    theMineCD.DoAction(PlantMine);
                }
            }
        }
    }

    void PlantMine()
    {
        for (int i = 0; i < minePool.allObjs.Count; i++)
        {
            if(!minePool.allObjs[i].activeInHierarchy)
            {
                minePool.allObjs[i].SetActive(true);
                minePool.allObjs[i].transform.position = minePositions[rando].position;
                //print("planted a mine");
                break;
            }
        }
    }


}

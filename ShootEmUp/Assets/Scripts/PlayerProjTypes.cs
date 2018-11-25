using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjTypes : MonoBehaviour {

    public float shotSpeed = 20f;

    public int bulletCount;
    public int homingMissileCount = 15;
    public GameObject regularshot;
    public GameObject homingMissile;
    ObjectPool regularshotpool;
    ObjectPool homingMissilePool;
    Transform up;

    private void Start()
    {
        homingMissilePool = new ObjectPool();
        homingMissilePool.StartUpThePool(homingMissileCount, homingMissile);
        regularshotpool = new ObjectPool();
        regularshotpool.StartUpThePool(bulletCount, regularshot);
        up = transform.GetChild(0);

    }

    public void ShootStuffUp()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (!regularshotpool.allObjs[i].activeInHierarchy)
            {
                regularshotpool.allObjs[i].SetActive(true);
                regularshotpool.allObjs[i].transform.position = up.position;
                regularshotpool.allObjs[i].GetComponent<Rigidbody2D>().velocity = Vector2.up * shotSpeed;
                break;
            }
        }
    }


    public void HomingMissile(Vector3 targetPos, float missileSpeed, float rotateSpeed)
    {
        var dir = transform.position - targetPos;

        dir.Normalize();

        var val = Vector3.Cross(dir, transform.right).z;
        


        for (int i = 0; i < bulletCount; i++)
        {
            if (!homingMissilePool.allObjs[i].activeInHierarchy)
            {
                homingMissilePool.allObjs[i].SetActive(true);
                homingMissilePool.allObjs[i].transform.position = up.position;
                homingMissilePool.allObjs[i].GetComponent<Rigidbody2D>().angularVelocity = rotateSpeed * val;
                //homingMissilePool.projectiles[i].GetComponent<Rigidbody2D>().velocity = transform.right * missileSpeed;
                break;
            }
        }
    }


    //public void HomingMissile(Vector2 targetPos, float turn_rate, float missileSpeed)
    //{
    //    var targetAngle = Vector2.Angle(this.transform.position, targetPos);

    //    //var theTargetAngle = new Quaternion(0, 0, targetAngle, 0);

    //    if(transform.rotation.z != targetAngle)
    //    {
    //        var delta = targetAngle - transform.rotation.z;

    //        if (delta > Mathf.PI) delta -= Mathf.PI * 2;
    //        if (delta < -Mathf.PI) delta += Mathf.PI * 2;

    //        if(delta > 0)
    //        {
    //            transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y, turn_rate));
    //        }
    //        else
    //        {
    //            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -turn_rate));
    //        }

    //        for (int i = 0; i < bulletCount; i++)
    //        {
    //            if(!homingMissilePool.projectiles[i].activeInHierarchy)
    //            {
    //                homingMissilePool.projectiles[i].SetActive(true);
    //                homingMissilePool.projectiles[i].transform.position = up.position;
    //                homingMissilePool.projectiles[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z)) * missileSpeed;
    //                break;
    //            }
    //        }

    //    }
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float homingMissileRotateSpeed = 20f;
    public float homingMissileSpeed = 5f;

    public float secondsBetweenShotsProjs = 0.05f;
    public float secsBetweenHomingMissile = 5f;

    float nextPosShotTime;
    PlayerProjTypes pProjs;

    public Transform dummytarget;

    private void Start()
    {
        pProjs = GetComponent<PlayerProjTypes>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (CanShoot())
            {
                pProjs.ShootStuffUp();
                nextPosShotTime = Time.time + secondsBetweenShotsProjs;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(CanShoot())
            {
                pProjs.HomingMissile(dummytarget.position, homingMissileSpeed, homingMissileRotateSpeed);
                nextPosShotTime = Time.time + secsBetweenHomingMissile;
            }
        }
    }

    private bool CanShoot()
    {
        bool ifcanshoot = true;
        if (Time.time < nextPosShotTime)
        {
            ifcanshoot = false;
        }
        return ifcanshoot;
    }
}

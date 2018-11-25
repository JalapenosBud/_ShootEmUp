using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public LayerMask WhatIsEnemyType;
    public float timer = 0f;
    //this is how long the timer should run before the bullet destroys itself
    public float travelDuration = 2f;
    public float radiusndistance = 0.3f;
    Timer cd = new Timer();
    
    //int cntr = 0;

    void OnEnable()
    {
        timer = 0;
    }

    void Update()
    {
        HitStuff();
        CountDown();
    }

    void DisableObject(GameObject go)
    {
        go.SetActive(false);
    }

    void CountDown()
    {
        timer += Time.deltaTime;
        if (timer >= travelDuration)
        {
            DisableObject(gameObject);
        }
        //cd.Update();
    }

    void HitStuff()
    {
        var hit = Physics2D.CircleCast(transform.position, radiusndistance, Vector2.zero, radiusndistance, WhatIsEnemyType);
        if (hit)
        {
            if(hit.collider.gameObject.layer == 9) //player layer
            {
                //hit.collider.gameObject.GetComponent<PlayerHealthController>().PlayerTakeDamage(1f, this.transform);
                DisableObject(gameObject);
            }
            else if(hit.collider.gameObject.layer == 10) //enemy layer
            {
                hit.collider.gameObject.GetComponent<EnemyHealthController>().TakeDamage(1f);
                DisableObject(gameObject);
            }

            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {

            this.gameObject.SetActive(false);
        }
    }
}

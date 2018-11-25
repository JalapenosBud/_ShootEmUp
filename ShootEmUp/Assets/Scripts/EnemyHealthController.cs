using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour {

    public float health = 15f;
    public float newHealth = 15f;
    EnemyBase eb;


    public delegate void OnEnemyDeath();
    public static event OnEnemyDeath Dies;


    private void Start()
    {
        eb = GetComponent<EnemyBase>();

    }

    protected void OnEnable()
    {
        health = newHealth;
                
    }

    protected void Update()
    {
        if (health <= 0)
        {
            
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (Dies != null)
        {
            Dies();
        }
    }

    public void TakeDamage(float damage, float slowdownspeed = 2f)
    {
        health -= damage;
        StartCoroutine(TakeDamageAgain(slowdownspeed));
    }

    IEnumerator TakeDamageAgain(float slowdown)
    {
        eb.flySpeed /= slowdown;
        yield return new WaitForSeconds(1f);
        eb.flySpeed = eb.prevflyspeed;
    }

}

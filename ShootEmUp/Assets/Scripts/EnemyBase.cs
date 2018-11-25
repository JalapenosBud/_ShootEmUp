using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealthController))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour {

    [HideInInspector]
    public Rigidbody2D rb2d;
    public float prevflyspeed;
    public float flySpeed;
    public Vector2 direction;


    protected virtual void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}

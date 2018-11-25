using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(DiffProjTypes))]
[RequireComponent(typeof(EnemyShootingScript))]
public class EnemyStandardShooter : EnemyBase {

    CountdownScript flyLeftCD;
    CountdownScript flyRightCD;
    CountdownScript flyDownCD;
    EnemyShootingScript shoot;
    DiffProjTypes proj;

    protected override void Start()
    {
        base.Start();
        flyLeftCD = new CountdownScript(3f, 3f, 2f, 2f);
        flyRightCD = new CountdownScript(6f, 6f, 2f, 2f);
        flyDownCD = new CountdownScript(0.2f, 5f, 0.5f, 0.5f);
        shoot = GetComponent<EnemyShootingScript>();
        proj = GetComponent<DiffProjTypes>();
    }

    protected void Update()
    {
        flyDownCD.DoAction(FlyDown);
        flyLeftCD.DoAction(FlyLeft);
        flyRightCD.DoAction(FlyRight);
        shoot.Shoot(proj.Shoot);
    }

    void FlyDown()
    {
        rb2d.velocity = Vector2.down;
    }

    void FlyRight()
    {
        rb2d.velocity = Vector2.right * flySpeed;
    }

    void FlyLeft()
    {
        rb2d.velocity = Vector2.left * flySpeed;
    }

}

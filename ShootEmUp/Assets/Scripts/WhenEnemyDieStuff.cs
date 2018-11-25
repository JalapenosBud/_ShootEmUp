using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenEnemyDieStuff : MonoBehaviour {

    public static WhenEnemyDieStuff instance;

    private void Awake()
    {
        instance = this;
    }

}

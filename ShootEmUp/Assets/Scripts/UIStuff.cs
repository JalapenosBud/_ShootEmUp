using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour {

    Text comboText;
    UtilityManager util = new UtilityManager();

    private void Start()
    {
        comboText = transform.GetChild(0).GetComponent<Text>();
        EnemyHealthController.Dies += (() => { util.startToFade = true; print("enemy deded"); });
    }

    private void Update()
    {
        util.FadeOutForUIText(comboText.gameObject, 2f);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* This is used to make a "pool" of objects to use in the class "DiffProjTypes"
*
*/

public class ObjectPool
{
    public List<GameObject> allObjs;

    //always call this function first
    public void StartUpThePool(int amount, GameObject theObj) 
    {
        GameObject newObj;

        allObjs = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            newObj = GameObject.Instantiate(theObj);
            newObj.SetActive(false);
            allObjs.Add(newObj);
        }
    }

}

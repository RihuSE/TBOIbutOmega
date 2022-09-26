using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rooms : MonoBehaviour
{
    public GameObject enemyNumber;
    public GameObject[] doorCLoser;
    private bool doorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber.transform.childCount == 0 && doorOpened == false)
        {
            int a = UnityEngine.Random.Range(0, 4);
            Destroy(doorCLoser[a]);
            int b = UnityEngine.Random.Range(0, 4);
            while (a == b)
            {
                b = UnityEngine.Random.Range(0, 4);
            }
            Destroy(doorCLoser[b]);
            doorOpened = true;
        }
    }
}

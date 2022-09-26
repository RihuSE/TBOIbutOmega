using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropletLife : MonoBehaviour
{
    [SerializeField] private float dropletRemainTime;


    void Start()
    {
        StartCoroutine(dropletDie());
    }

    IEnumerator dropletDie()
    {
        yield return new WaitForSeconds(dropletRemainTime);
        Destroy(gameObject);
    }
}

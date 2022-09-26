using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fireflyAI : MonoBehaviour
{
    [HideInInspector] public Transform playerPosition;
    NavMeshAgent fireeFlyyy;
    void Start()
    {
        fireeFlyyy = GetComponent<NavMeshAgent>();
        fireeFlyyy.updateRotation = false;
        fireeFlyyy.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("player").GetComponent<Transform>();
        fireeFlyyy.SetDestination(playerPosition.position);
    }
}

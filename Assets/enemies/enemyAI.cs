using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    [HideInInspector] public Transform playerPosition;
    NavMeshAgent fireFighter;

    Animator animator;

    public Vector2 currentPosition;
    public Vector2 lastPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        fireFighter = GetComponent<NavMeshAgent>();
        fireFighter.updateRotation = false;
        fireFighter.updateUpAxis = false;
        currentPosition = transform.position;
    }

    void Update()
    {
        playerPosition = GameObject.Find("player").GetComponent<Transform>();
        fireFighter.SetDestination(playerPosition.position);
        movementAnimation();
    }
    private void movementAnimation()
    {
        lastPosition = currentPosition;
        currentPosition = transform.position;
        if (currentPosition.x > lastPosition.x) animator.SetFloat("X", 1f);
        else animator.SetFloat("X", -1f);
    }
}

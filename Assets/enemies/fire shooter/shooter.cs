using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class shooter : MonoBehaviour
{
    [HideInInspector] public Transform playerPosition;
    public GameObject dropletFirePrefab;
    Quaternion rotation;

    private float nextShoot = 0;
    [SerializeField] private float shootRate = 2.75f;
    [SerializeField] private float dropletSpeed = 5f;
    void Update()
    {
        rotation = Quaternion.Euler(0, 0, 0);
        playerPosition = GameObject.Find("player").GetComponent<Transform>();
        transform.LookAt(playerPosition.position);
        shooting();
    }
    private void shooting()
    {
        if (Vector2.Distance(playerPosition.position, transform.position) < 5 && Time.time >= nextShoot)
        {
            GameObject dropletFire = Instantiate(dropletFirePrefab, transform.position, rotation) as GameObject;
            dropletFire.GetComponent<Rigidbody2D>().velocity = transform.forward * dropletSpeed;

            nextShoot = Time.time + shootRate;
        }
    }
}

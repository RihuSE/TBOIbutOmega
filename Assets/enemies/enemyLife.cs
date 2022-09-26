using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    public float health;

    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D droplet)
    {
        if (droplet.gameObject.tag == "droplet")
        {
            health -= GameObject.Find("player").GetComponent<playerController>().damage;
            Destroy(droplet.gameObject);
            Debug.Log(health);
        }
    }
}

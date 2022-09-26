using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public GameObject dropletPrefab;

    private float moveX, moveY;
    Vector2 move;
    [SerializeField] private float speed = 7f;

    private float shootX, shootY, nextShoot = 0f;
    [SerializeField] private float shootRate = 3f;
    [SerializeField] private float dropletSpeed = 5f;
    public float damage;

    public float health = 3;
    [SerializeField] private float resistanceTime = 1f;
    public bool resistanceBool = false;

    [SerializeField] Text HP;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HP.text = health.ToString();
        Debug.Log(health);
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (animator != null)
        {
            animator.SetFloat("X", moveX);
            animator.SetFloat("Y", moveY);
        }

        shootX = Input.GetAxis("ShootHorizontal");
        shootY = Input.GetAxis("ShootVertical");

        shooting();
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void FixedUpdate()
    {
        movement();
    }
    private void movement()
    {
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime * speed);
    }
    private void shooting()
    {
        if ((shootX != 0 || shootY != 0) && Time.time >= nextShoot)
        {
            GameObject droplet = Instantiate(dropletPrefab, transform.position, transform.rotation) as GameObject;
            droplet.GetComponent<Rigidbody2D>().velocity = new Vector2((shootX < 0) ? Mathf.Floor(shootX) : Mathf.Ceil(shootX),
                                                                       (shootY < 0) ? Mathf.Floor(shootY) : Mathf.Ceil(shootY)) * dropletSpeed;
            nextShoot = Time.time + shootRate;
        }
    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (resistanceBool == false && enemy.gameObject.tag == "enemy")
        {
            health -= 1;
            resistanceBool = true;
            Invoke("immortality", resistanceTime);
        }
        if (resistanceBool == false && enemy.gameObject.tag == "fire droplet")
        {
            health -= 1;
            Destroy(enemy.gameObject);
            resistanceBool = true;
            Invoke("immortality", resistanceTime);
        }
    }

    private void immortality()
    {
        resistanceBool = false;
    }
}

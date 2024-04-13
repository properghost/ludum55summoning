using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoblinAI : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float distanceBetween;
    [SerializeField] internal Transform target;
    internal bool facingRight;
    internal float distance;
    internal float speed;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Knight").transform;
        player = GameObject.FindGameObjectWithTag("Knight");
        enemySpeed = 4f;
        distanceBetween = 1;
        maxHealth = 100f;
        healthSlider.maxValue = 100;
        healthSlider.value = maxHealth;
    }
    void Update()
    {
        healthSlider.value = maxHealth;
        if (Vector3.Distance(target.position,transform.position)<20)
        {
            transform.position=Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(target.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
            Flip();
            if(target.position.x < transform.position.x && facingRight)
            Flip();
        }

        if(currentHealth >= 0f)
        {
            Destroy(gameObject, 0.01f);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Knight")
        {
            currentHealth -= 0.01f;
        }
    }
   
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        


        if(distance > distanceBetween)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
    }
    void Flip()
    {
         Vector3 scale = transform.localScale;
         scale.x *= -1;
         transform.localScale = scale;
         facingRight = !facingRight;
    }

    
}

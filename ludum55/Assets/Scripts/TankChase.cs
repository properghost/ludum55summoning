using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankChase : MonoBehaviour
{
    public GameObject goblinOrPlayer;
    public float enemySpeed;
    public float distanceBetween;
    [SerializeField] private Transform target;
    internal bool facingRight;
    internal float distance;
    internal float speed;
    public float knightMaxHealth;
    public float knightCurrentHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject torchGoblin;
    public bool isGoblinAlive;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject expOrb;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        goblinOrPlayer = GameObject.FindGameObjectWithTag("Player");
        healthSlider.maxValue = knightMaxHealth;
        healthSlider.value = knightCurrentHealth;
        knightCurrentHealth = knightMaxHealth;
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        goblinOrPlayer = GameObject.FindGameObjectWithTag("Player");
        isGoblinAlive = false;

        


        healthSlider.value = knightCurrentHealth;
        if (Vector3.Distance(target.position,transform.position)<20)
        {
            transform.position=Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(target.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
            Flip();
            if(target.position.x < transform.position.x && facingRight)
            Flip();
        }

        if(knightCurrentHealth <= 0f)
        {
            Instantiate(expOrb, transform.position, transform.rotation);
            Destroy(gameObject, 0.01f);
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Debug.Log("goblin touched by knight, should damage");
            target.GetComponent<PlayerController>().playerCurrentHealth -= 0.1f;
        }
    }
   
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, goblinOrPlayer.transform.position);
        Vector2 direction = goblinOrPlayer.transform.position - transform.position;
        direction.Normalize();
        


        if(distance > distanceBetween)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, goblinOrPlayer.transform.position, enemySpeed * Time.deltaTime);
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

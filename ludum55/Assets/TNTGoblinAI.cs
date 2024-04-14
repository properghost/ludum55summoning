using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TNTGoblinAI : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float distanceBetween;
    [SerializeField] internal Transform target;
    internal bool facingRight;
    internal float distance;
    internal float speed;
    public float goblinTNTCurrentHealth;
    public float goblinMaxHealth;
    [SerializeField] private float healthDecayValue;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject simpleKnight;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Knight").transform;
        player = GameObject.FindGameObjectWithTag("Knight");
        goblinTNTCurrentHealth = goblinMaxHealth;
        healthSlider.maxValue = goblinMaxHealth;
        healthSlider.value = goblinMaxHealth;
    }
    void Update()
    {
        goblinTNTCurrentHealth -= Time.deltaTime * healthDecayValue;
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Knight");
        }

        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Knight").transform;
        }
        healthSlider.value = goblinTNTCurrentHealth;
        if (Vector3.Distance(target.position,transform.position)<20)
        {
            transform.position=Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(target.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
            Flip();
            if(target.position.x < transform.position.x && facingRight)
            Flip();
        }

        if(goblinTNTCurrentHealth <= 0f)
        {
            Destroy(gameObject, 0.01f);
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

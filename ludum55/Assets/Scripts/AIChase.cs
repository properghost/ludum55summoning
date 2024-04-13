using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float distanceBetween;
    [SerializeField] private Transform target;
    private bool facingRight;
    private float distance;
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
         if (Vector3.Distance(target.position,transform.position)<20)
         {
             transform.position=Vector2.MoveTowards(transform.position, target.position,speed * Time.deltaTime);
             if(target.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
                 Flip();
             if(target.position.x < transform.position.x && facingRight)
                 Flip();
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
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float distanceBetween;
    
    private float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}

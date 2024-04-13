using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if(distance > 1)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}

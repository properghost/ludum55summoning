using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject enemyEntity;
    public float targetedObject;
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyEntity = GameObject.FindGameObjectWithTag("Knight");
        targetedObject = Vector2.Distance(transform.position, enemyEntity.transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, enemyEntity.transform.position, moveSpeed * Time.deltaTime);

        if(targetedObject <= 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, -enemyEntity.transform.position, moveSpeed * 3 * Time.deltaTime);
        }

        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}

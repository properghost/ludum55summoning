using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarelGoblinAI : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float distanceBetween;
    [SerializeField] internal Transform target;
    internal bool facingRight;
    internal float distance;
    internal float speed;
    public float goblinCurrentHealth;
    public float goblinMaxHealth;
    [SerializeField] private float healthDecayValue;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject simpleKnight;
    private ParticleSystem particleExplosion;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("TankKnight").transform;
        player = GameObject.FindGameObjectWithTag("TankKnight");
        distanceBetween = 1;
        goblinMaxHealth = 100f;
        goblinCurrentHealth = goblinMaxHealth;
        healthSlider.maxValue = 100;
        healthSlider.value = goblinMaxHealth;
        particleExplosion = GetComponent<ParticleSystem>();
        particleExplosion.Stop();
    }
    void Update()
    {

        goblinCurrentHealth -= Time.deltaTime * healthDecayValue;
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("TankKnight");
        }

        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("TankKnight").transform;
        }
        healthSlider.value = goblinCurrentHealth;
        if (Vector3.Distance(target.position,transform.position)<20)
        {
            transform.position=Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(target.position.x > transform.position.x && !facingRight) //if the target is to the right of enemy and the enemy is not facing right
            Flip();
            if(target.position.x < transform.position.x && facingRight)
            Flip();
        }

        if(goblinCurrentHealth <= 0f)
        {
            Destroy(gameObject, 0.01f);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "TankKnight")
        {
            particleExplosion.Play();
            Debug.Log("knight touched by knight, should damage");
            target.GetComponent<TankChase>().knightCurrentHealth -= 1f;
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

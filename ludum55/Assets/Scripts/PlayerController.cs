using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    Vector2 moveDir;
    public float playerCurrentHealth;
    public float playerMaxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] public float currentExperience;
    //[SerializeField] public float maxExperience;
    [SerializeField] public float currentLevel;
    [SerializeField] private float neededExp;
    void Start()
    {
        healthSlider.maxValue = 100;
        healthSlider.value = playerCurrentHealth;
        playerMaxHealth = 100f;
        playerCurrentHealth = playerMaxHealth;
        rb = GetComponent<Rigidbody2D>();
        currentLevel = 1;
        //maxExperience = neededExp;
    }
    void Update()
    {

        healthSlider.value = playerCurrentHealth;
        InputManagement();

        if(playerCurrentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if(currentExperience >= 10 && currentLevel == 0)
        {
            moveSpeed += 1f;
            currentLevel++;
        }
        else if(currentExperience >= 20 && currentLevel == 1)
        {
            moveSpeed += 3f;
            currentLevel++;
        }
        else if (currentExperience >= 30 && currentLevel == 2)
        {
            moveSpeed += 5;
            currentLevel++;
        }
        else if(currentExperience >= 40 && currentLevel == 3)
        {
            moveSpeed += 10f;
            currentLevel++;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ExpOrb")
        {
            Destroy(other.gameObject);
            currentExperience += 1;
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float moveY = Input.GetAxisRaw("Vertical") * moveSpeed;

        moveDir = new Vector2(moveX, moveY).normalized;
        
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}

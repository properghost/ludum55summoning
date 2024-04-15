using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SummonSystem summonSystem;

    public float moveSpeed;
    private float moveX;
    private float moveY;
    private Rigidbody2D rb;
    Vector2 moveDir;
    public float playerCurrentHealth;
    public float playerMaxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider expSlider;
    [SerializeField] public float currentExperience;
    //[SerializeField] public float maxExperience;
    [SerializeField] public float currentLevel;
    [SerializeField] private float neededExp;
    [SerializeField] private Animator animator;
    private bool isRunning;
    
    void Start()
    {
        summonSystem = GetComponent<SummonSystem>();
        healthSlider.maxValue = 100;
        expSlider.maxValue = 10;
        expSlider.value = currentLevel;
        healthSlider.value = playerCurrentHealth;
        playerMaxHealth = 100f;
        playerCurrentHealth = playerMaxHealth;
        rb = GetComponent<Rigidbody2D>();
        currentLevel = 0;
        //maxExperience = neededExp;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        healthSlider.maxValue = playerMaxHealth;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

        if(rb.velocity.magnitude >= 3)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        healthSlider.value = playerCurrentHealth;
        InputManagement();

        if(playerCurrentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if(currentExperience >= 50 && currentLevel == 0)
        {
            moveSpeed += 1f;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 5f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 150 && currentLevel == 1)
        {
            moveSpeed += 1f;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 5f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if (currentExperience >= 300 && currentLevel == 2)
        {
            moveSpeed += 1;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 450 && currentLevel == 3)
        {
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 600 && currentLevel == 4)
        {
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 750 && currentLevel == 5)
        {
            moveSpeed += 1f;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 850 && currentLevel == 6)
        {
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 950 && currentLevel == 7)
        {
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 1050 && currentLevel == 8)
        {
            moveSpeed += 0.5f;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }
        else if(currentExperience >= 1250 && currentLevel == 9)
        {
            moveSpeed += 0.5f;
            currentLevel++;
            expSlider.value = currentLevel;
            summonSystem.maxMana += 10f;
            playerCurrentHealth += 30f;
            playerMaxHealth += 10f;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ExpOrb")
        {
            Destroy(other.gameObject);
            currentExperience += 1;
        }
        else if (other.gameObject.tag == "HpOrb" && playerCurrentHealth <= playerMaxHealth)
        {
            Destroy(other.gameObject);
            playerCurrentHealth += 2f;
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

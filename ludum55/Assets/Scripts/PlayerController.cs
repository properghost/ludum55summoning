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
    [SerializeField] int currentExperience;
    [SerializeField] int maxExperience;
    [SerializeField] int currentLevel;
    void Start()
    {
        healthSlider.maxValue = 100;
        healthSlider.value = playerCurrentHealth;
        playerMaxHealth = 100f;
        playerCurrentHealth = playerMaxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        healthSlider.value = playerCurrentHealth;
        InputManagement();

        if(playerCurrentHealth <= 0)
        {
            SceneManager.LoadScene(0);
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

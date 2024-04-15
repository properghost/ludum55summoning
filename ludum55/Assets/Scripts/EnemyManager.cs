using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
[SerializeField] GameObject enemy;
//[SerializeField] private AIChase simpleKnightSpeedModifier;
[SerializeField] GameObject endBoss;
[SerializeField] Vector2 spawnArea;
[SerializeField] float spawnTimer;
[SerializeField]float waveTimer;
[SerializeField] Transform player;
float timer;
float timerTwo;
[SerializeField] public float gameTime;
private bool lvlOne;
private bool lvlTwo;
private bool lvlThree;
private bool lvlFour;
private bool lvlFive;
private bool lvlSix;
private bool lvlSeven;
private bool lvlEight;
private bool lvlNine;
private bool lvlTen;


private void Start()
{
    //simpleKnightSpeedModifier = GetComponent<AIChase>();
    timerTwo = waveTimer;
    lvlOne = false;
    lvlTwo = false;
    lvlThree = false;
    lvlFour = false;
    lvlFive = false;
    lvlFive = false;
    lvlSix = false;
    lvlSeven = false;
    lvlEight = false;
    lvlNine = false;
    lvlTen = false;
}
private void Update()
{
    gameTime += Time.deltaTime;

    if (gameTime >= 1040 && !lvlTen)
    {
        SpawnBoss();
        SpawnBoss();
        SpawnBoss();
        waveTimer += 3f;
        //simpleKnightSpeedModifier.enemySpeed += 0.4f;
        lvlNine = true;
    }
    else if (gameTime >= 920 && !lvlNine)
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        //simpleKnightSpeedModifier.enemySpeed += 0.2f;
        lvlNine = true;
    } 
    else if (gameTime >= 860 && !lvlEight)
    {
        SpawnBoss();
        SpawnBoss();
        SpawnBoss();
        spawnTimer -= 0.1f;
        waveTimer += 3f;
       // simpleKnightSpeedModifier.enemySpeed += 0.3f;
        lvlEight = true;
    }
    else if(gameTime >= 720 && !lvlSeven)
    {
        SpawnBoss();
        SpawnBoss();
        spawnTimer -= 0.1f;
        waveTimer += 3f;
        //simpleKnightSpeedModifier.enemySpeed += 0.1f;
        lvlSeven = true;
    }
    else if(gameTime >= 600 && !lvlSix)
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        waveTimer += 3f;
        lvlSix = true;
    }
    else if (gameTime >= 480 && !lvlFive)
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnBoss();
        //simpleKnightSpeedModifier.enemySpeed += 0.2f;
        lvlFive = true;
        
    }
    else if (gameTime >= 420 && !lvlFour)
    {
        //simpleKnightSpeedModifier.enemySpeed += 0.2f;
        spawnTimer -= 1f;
        lvlFour = true;
    }
    else if (gameTime >= 360 && !lvlThree)
    {
        //simpleKnightSpeedModifier.enemySpeed += 0.3f;
        spawnTimer -= .5f;
        lvlThree = true;
    }
    else if(gameTime >= 180 && !lvlTwo)
    {
        spawnTimer -= 0.4f;
        lvlTwo = true;
    }
    else if(gameTime >= 60 && !lvlOne)
    {
        //simpleKnightSpeedModifier.enemySpeed += 0.1f;
        spawnTimer -= 0.1f;
        lvlOne = true;
    }


    timer -= Time.deltaTime;
    timerTwo -= Time.deltaTime;
    if (timer < 0f)
    {
        SpawnEnemy();
        timer = spawnTimer;
    }

    if (timerTwo < 0f)
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        timerTwo = waveTimer;
    }
}
private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
    }

    private void SpawnBoss()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newBoss = Instantiate(endBoss);
        newBoss.transform.position = position;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }
        
        
        position.z = 0;


        return position;
    }
}
//     private void TimerTwoReset()
//     {
//         timerTwo = waveTimer;
//     }
//     private void DebugMethod()
//     {
//         Debug.Log("Yarra yedi");
//     }
// }

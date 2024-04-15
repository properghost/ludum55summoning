using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
[SerializeField] GameObject enemy;
[SerializeField] GameObject endBoss;
[SerializeField] Vector2 spawnArea;
[SerializeField] float spawnTimer;
[SerializeField]float waveTimer;
[SerializeField] Transform player;
float timer;
float timerTwo;
float gameTime;

private void Start()
{
    timerTwo = waveTimer;
}
private void Update()
{
    gameTime += Time.deltaTime;

    if (gameTime >= 600)
    {
        SpawnBoss();
        spawnTimer = 5f;
        
    }
    else if (gameTime >= 540)
    {
        spawnTimer -= 1f;
    }
    else if (gameTime >= 360)
    {
        spawnTimer -= .5f;
    }
    else if(gameTime >= 180)
    {
        spawnTimer -= 0.4f;
    }
    else if(gameTime >= 60)
    {
        spawnTimer -= 0.1f;
    }
    timer -= Time.deltaTime;
    timerTwo -= Time.deltaTime;
    if (timer < 0f)
    {
        SpawnEnemy();
        timer = spawnTimer;
    }

    // if (timerTwo < 0f)
    // {
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     SpawnEnemy();
    //     timerTwo = waveTimer;
    // }
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

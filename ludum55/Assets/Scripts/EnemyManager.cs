using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
[SerializeField] GameObject enemy;
[SerializeField] Vector2 spawnArea;
[SerializeField] float spawnTimer;
float timer;

private void Update()
{
    timer -= Time.deltaTime;
    if (timer < 0f)
    {
        SpawnEnemy();
        timer = spawnTimer;
    }
}
private void SpawnEnemy()
{
    Vector3 position = new Vector3(
    UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
    UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
    0f);

    GameObject newEnemy = Instantiate(enemy);
    newEnemy.transform.position = position;
}
}

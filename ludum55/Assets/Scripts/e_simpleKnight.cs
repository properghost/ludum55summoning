using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_simpleKnight : AIChase
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        player = GameObject.Find("Player");
        enemySpeed = 3f;
        distanceBetween = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

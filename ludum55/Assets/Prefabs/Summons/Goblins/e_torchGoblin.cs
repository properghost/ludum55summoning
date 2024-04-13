using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_torchGoblin : AIChase
{
    // Start is called before the first frame update
    void Start()
    {
        enemySpeed = 3f;
        distanceBetween = 0.002f;
        target = GameObject.FindGameObjectWithTag("Knight").transform;
        player = GameObject.FindGameObjectWithTag("Knight");
    }

    // Update is called once per frame
    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TNTThrowAI : MonoBehaviour
{
    [SerializeField] internal GameObject whatToThrow;
    [SerializeField] internal Transform selfTransform;
    private float cooldownTimer;
    [SerializeField] private float cooldownTime;



    void Update()
    {


        cooldownTimer -= Time.deltaTime;
        
        if(cooldownTimer <= cooldownTime)
        {
        ThrowingProjectile();
        cooldownTimer = 0f;
        }
        

    }

    private void ThrowingProjectile()
    {
        Instantiate(whatToThrow, selfTransform.position, selfTransform.rotation);
        //thrownObjectTransform.position=Vector2.MoveTowards(thrownObjectTransform.position, targetTransform.position, projectileSpeed * Time.deltaTime);
    }
}

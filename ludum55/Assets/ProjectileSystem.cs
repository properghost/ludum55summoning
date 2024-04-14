using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    [SerializeField] internal GameObject whatToThrow;
    internal Transform thrownObjectTransform;
    internal GameObject targetObject;
    internal Transform targetTransform;
    internal Transform selfTransform;
    internal float projectileSpeed;
    internal float waitTimeParameter;

    void Update()
    {
        if(targetTransform != null)
        {

        StartCoroutine(ThrowCoroutine());
        }
    }

    private void ThrowProjectile()
    {
        Instantiate(whatToThrow, selfTransform.position, selfTransform.rotation);
        thrownObjectTransform.position=Vector2.MoveTowards(thrownObjectTransform.position, targetTransform.position, projectileSpeed * Time.deltaTime);
    }

    IEnumerator ThrowCoroutine()
    {
        ThrowProjectile();
        yield return new WaitForSeconds(waitTimeParameter);
    }
}

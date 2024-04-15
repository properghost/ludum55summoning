using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileTNT : MonoBehaviour
{
    private ParticleSystem particleExplosion;
    // Start is called before the first frame update
    void Start()
    {
        particleExplosion = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knight")
        {
            other.GetComponent<AIChase>().knightCurrentHealth = -0.01f;
            particleExplosion.Play();
            Destroy(gameObject, 0.1f);
        }
    }
}

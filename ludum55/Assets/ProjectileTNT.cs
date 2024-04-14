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
        particleExplosion.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Knight")
        {
            other.GetComponent<AIChase>().knightCurrentHealth = -0.1f;
            particleExplosion.Play();
            Destroy(gameObject, 1f);
        }
    }
}

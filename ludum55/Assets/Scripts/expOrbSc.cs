using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expOrbSc : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.currentExperience += 1;
            Destroy(gameObject);
        }
    }
}

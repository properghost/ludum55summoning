using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightDamager : MonoBehaviour
{
    [SerializeField] private GameObject torchGoblin;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goblin")
        {
            Debug.Log("goblin touched by knight, should damage");
            torchGoblin.GetComponent<GoblinAI>().goblinCurrentHealth -= 1f;
        }
    }
}

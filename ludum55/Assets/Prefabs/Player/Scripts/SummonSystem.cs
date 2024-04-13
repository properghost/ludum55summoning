using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SummonSystem : MonoBehaviour
{
    [SerializeField] private bool runeOne;
    [SerializeField] private bool runeTwo;

    [SerializeField] private bool runeThree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            runeOne = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            runeTwo = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            runeThree = true;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SummonSystem : MonoBehaviour
{
    //Rune One
    [SerializeField] private bool runeOne;
    [SerializeField] private bool alRune;
    [SerializeField] private bool alRuneUsed;
    //----------------------------------------
    //Rune Two
    [SerializeField] private bool runeTwo;
    [SerializeField] private bool gamRune;
    [SerializeField] private bool gamRuneUsed;
    //----------------------------------------
    [SerializeField] private bool runeThree;
    [SerializeField] private bool bazRune;
    [SerializeField] private bool bazRuneUsed;
    //----------------------------------------
    public int runeVal;

    // Start is called before the first frame update
    void Start()
    {
        runeVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            runeOne = true;
            alRune = true;
            if(alRune && !alRuneUsed)
            {
                Invoke("AlRuneActivate", 0);
                alRuneUsed = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            runeTwo = true;
            gamRune = true;
            if(gamRune && !gamRuneUsed)
            {
                Invoke("GamRuneActivate", 0);
                gamRuneUsed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            runeThree = true;
            bazRuneUsed = true;
            if(bazRune && !bazRuneUsed)
            {
                Invoke("BazRuneActivate", 0);
                bazRuneUsed = true;
            }

        }
    }

    private void AlRuneActivate()
    {
        runeVal += 5;
    }
    private void GamRuneActivate()
    {
        runeVal *= 2;
    }
    private void BazRuneActivate()
    {
        runeVal = runeVal * (runeVal / 4);
    }
}

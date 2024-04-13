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
    public float runeVal;
    public float alRuneVal;
    public float gamRuneVal;
    public float bazRuneVal;

    // Start is called before the first frame update
    void Start()
    {
        runeVal = 1f;
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
            bazRune = true;
            if(bazRune && !bazRuneUsed)
            {
                Invoke("BazRuneActivate", 0);
                bazRuneUsed = true;
            }

        }

        


    }

    private void AlRuneActivate()
    {
        runeVal = runeVal + 5f;
    }
    private void GamRuneActivate()
    {
        runeVal = runeVal * 2f;
        if(runeOne && runeThree)
        {
            runeVal = runeVal + 1f;
        }
    }
    private void BazRuneActivate()
    {
        runeVal = runeVal * 3f;
        if(runeThree && runeTwo)
        {
            runeVal = runeVal - 1f;
        }
    }
    // SUMMON VALUES ----------------------
    // 35

    // 37

    // 20

    // 10

    // 17

    // 11
    // SUMMON VALUES ----------------------
}

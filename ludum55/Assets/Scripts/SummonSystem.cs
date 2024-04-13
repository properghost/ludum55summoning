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
                if(bazRune && !gamRune)
                {
                bazRuneVal = 5;
                }
                else { bazRuneVal = 1f ;};
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
            if(alRune && !bazRune)
                {
                alRuneVal = 5;
                }
            else { alRuneVal = 2f ;};
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

        if(bazRuneVal == 5)
        {
            runeVal = 10f;
        }
    }

    private void AlRuneActivate()
    {
        runeVal += 5f;
    }
    private void GamRuneActivate()
    {
        runeVal = runeVal * (alRuneVal * 2f);
    }
    private void BazRuneActivate()
    {
        runeVal = runeVal * (bazRuneVal * 2f);
    }
}

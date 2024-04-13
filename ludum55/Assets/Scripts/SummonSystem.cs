using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SummonSystem : MonoBehaviour
{
    //Rune One
    private bool runeOne;
    private bool alRune;
    private float alRuneVal;
    private bool alRuneUsed;
    [SerializeField] private float alRuneManaCost;
    //----------------------------------------
    //Rune Two
    private bool runeTwo;
    private bool gamRune;
    private float gamRuneVal;
    private bool gamRuneUsed;
    [SerializeField] private float gamRuneManaCost;
    //----------------------------------------
    private bool runeThree;
    private bool bazRune;
    private float bazRuneVal;
    private bool bazRuneUsed;
    [SerializeField] private float bazRuneManaCost;
    //----------------------------------------
    public float runeVal;
    public float maxMana;
    public float currentMana;
    //SummonPrefabs---------------------------
    [SerializeField] private GameObject torchGoblin;

    // Start is called before the first frame update
    void Start()
    {
        runeVal = 1f;
        maxMana = 100f;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentMana -= alRuneManaCost;
            runeOne = true;
            alRune = true;
            if (alRune && !alRuneUsed)
            {
                Invoke("AlRuneActivate", 0);
                alRuneUsed = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMana -= gamRuneManaCost;
            runeTwo = true;
            gamRune = true;
            if (gamRune && !gamRuneUsed)
            {
                Invoke("GamRuneActivate", 0);
                gamRuneUsed = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentMana -= bazRuneManaCost;
            runeThree = true;
            bazRune = true;
            if (bazRune && !bazRuneUsed)
            {
                Invoke("BazRuneActivate", 0);
                bazRuneUsed = true;
            }
        }

        ActivateRunes();

    }

    private void ActivateRunes()
    {
        if (runeVal == 11 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0 || runeVal == 11 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
        {
            // REPLENISH MANA / 3 + 2 + 1
            currentMana = maxMana;
            runeOne = false;
            runeTwo = false;
            runeThree = false;
            alRune = false;
            gamRune = false;
            bazRune = false;
            alRuneUsed = false;
            gamRuneUsed = false;
            bazRuneUsed = false;
            runeVal = 1f;
        }

        if(currentMana <= 0 && Input.GetKeyDown(KeyCode.Space) && runeVal != 11)
        {
            // NOT ENOUGH MANA
            runeOne = false;
            runeTwo = false;
            runeThree = false;
            alRune = false;
            gamRune = false;
            bazRune = false;
            alRuneUsed = false;
            gamRuneUsed = false;
            bazRuneUsed = false;

            runeVal = 1f;
        }
        else if (runeOne && runeTwo && runeThree)
        {
            // SUMMON TORCH GOBLIN / 1 + 2 + 3
            if (runeVal == 35 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                Instantiate(torchGoblin, transform.position, transform.rotation);
                runeOne = false;
                runeTwo = false;
                runeThree = false;
                alRune = false;
                gamRune = false;
                bazRune = false;
                alRuneUsed = false;
                gamRuneUsed = false;
                bazRuneUsed = false;

                runeVal = 1f;
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
    // 35 - SUMMON TORCH GOBLIN / 1 + 2 + 3

    // 37 / 1 + 3 + 2

    // 20 / 2 + 1 + 3

    // 10 / 2 + 3 + 1 

    // 17 / 3 + 1 + 2

    // 11 - REPLENISH MANA / 3 + 2 + 1
    // SUMMON VALUES ----------------------
}

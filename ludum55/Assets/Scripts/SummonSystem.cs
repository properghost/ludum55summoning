using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.UI;

public class SummonSystem : MonoBehaviour
{
    //Rune One
    private bool runeOne;
    private bool alRune;
    private float alRuneVal;
    private bool alRuneUsed;
    [SerializeField] private RawImage alRuneImage;

    //----------------------------------------
    //Rune Two
    private bool runeTwo;
    private bool gamRune;
    private float gamRuneVal;
    private bool gamRuneUsed;
    [SerializeField] private RawImage gamRuneImage;
    //----------------------------------------
    private bool runeThree;
    private bool bazRune;
    private float bazRuneVal;
    private bool bazRuneUsed;
    [SerializeField] private RawImage bazRuneImage;
    //----------------------------------------
    public float runeVal;
    public float maxMana;
    public float currentMana;
    [SerializeField] private Slider manaSlider;
    //SummonPrefabs---------------------------
    [SerializeField] private GameObject torchGoblin;
    [SerializeField] private float torchGoblinManaCost;
    [SerializeField] private float TNTGoblinManaCost;
    [SerializeField] private GameObject TNTGoblin;

    // Start is called before the first frame update
    void Start()
    {
        runeVal = 1f;
        maxMana = 100f;
        currentMana = maxMana;
        manaSlider.maxValue = 100;
        manaSlider.value = currentMana;
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.value = currentMana;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            manaSlider.value = currentMana;
            //currentMana -= alRuneManaCost;
            runeOne = true;
            alRune = true;
            if (alRune && !alRuneUsed)
            {
                Invoke("AlRuneActivate", 0);
                alRuneUsed = true;
            }
        }

        if(!runeOne)
        {
            alRuneImage.enabled = false;
        }
        else if(runeOne)
        {
            alRuneImage.enabled = true;
        }

        if(!runeTwo)
        {
            gamRuneImage.enabled = false;
        }
        else if(runeTwo)
        {
            gamRuneImage.enabled = true;
        }

        if(!runeThree)
        {
            bazRuneImage.enabled= false;
        }
        else if(runeThree)
        {
            bazRuneImage.enabled = true;
        }



        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            manaSlider.value = currentMana;
            //currentMana -= gamRuneManaCost;
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
            manaSlider.value = currentMana;
            //currentMana -= bazRuneManaCost;
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
        if (runeVal == 11 && Input.GetKeyDown(KeyCode.Space))
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

        if (runeOne && runeTwo && runeThree)
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
                currentMana -= torchGoblinManaCost;
            }

        }

        if (runeOne && runeTwo && runeThree)
        {
            // SUMMON TNT GOBLIN / 1 + 3 + 2
            if (runeVal == 37 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                Instantiate(TNTGoblin, transform.position, transform.rotation);
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
                currentMana -= TNTGoblinManaCost;
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

    // 37 - SUMMON TNT GOBLIN / 1 + 3 + 2

    // 20 / 2 + 1 + 3

    // 10 / 2 + 3 + 1 

    // 17 / 3 + 1 + 2

    // 11 - REPLENISH MANA / 3 + 2 + 1
    // SUMMON VALUES ----------------------
}

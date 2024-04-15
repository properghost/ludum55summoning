using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SummonSystem : MonoBehaviour
{
    [SerializeField] private AudioSource spaceSound;
    [SerializeField] private AudioSource keyOneSound;
    [SerializeField] private AudioSource keyTwoSound;
    [SerializeField] private AudioSource keyThreeSound;
    [SerializeField] private PlayerController player;
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
    [SerializeField] private GameObject torchGoblinLvlTwo;
    [SerializeField] private GameObject torchGoblinLvlThree;
    [SerializeField] private GameObject torchGoblinLvlFour;
    [SerializeField] private float torchGoblinManaCost;
    [SerializeField] private RawImage torchGoblinPNG;
    [SerializeField] private float TNTGoblinManaCost;
    [SerializeField] private GameObject TNTGoblin;
    [SerializeField] private GameObject TNTGoblinLvlTwo;
    [SerializeField] private GameObject TNTGoblinLvlThree;
    [SerializeField] private GameObject TNTGoblinLvlFour;
    [SerializeField] private RawImage TNTGoblinPNG;
    [SerializeField] private float BarrelGoblinManaCost;
    [SerializeField] private GameObject BarrelGoblin;
    [SerializeField] private RawImage BarrelGoblinPNG;
    [SerializeField] private RawImage manaPNG;
    [SerializeField] private RawImage healthPNG;
    [SerializeField] private RawImage boostSpeedPNG;

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
        player = GetComponent<PlayerController>();
        manaSlider.value = currentMana;
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

        if(runeVal == 35)
        {
            torchGoblinPNG.enabled = true;
        }
        else if(runeVal != 35)
        {
            torchGoblinPNG.enabled = false;
        }

        if(runeVal == 37)
        {
            TNTGoblinPNG.enabled = true;
        }
        else if(runeVal != 37)
        {
            TNTGoblinPNG.enabled = false;
        }

        if(runeVal == 20)
        {
            BarrelGoblinPNG.enabled = true;
        }
        else if(runeVal != 20)
        {
            BarrelGoblinPNG.enabled = false;
        }

        if(runeVal == 17)
        {
            healthPNG.enabled = true;
        }
        else if(runeVal != 17)
        {
            healthPNG.enabled = false;
        }

        if(runeVal == 11)
        {
            manaPNG.enabled = true;
        }
        else if(runeVal != 11)
        {
            manaPNG.enabled= false;
        }

        if(runeVal == 10)
        {
            boostSpeedPNG.enabled = true;
        }
        else if(runeVal != 10)
        {
            boostSpeedPNG.enabled= false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            keyOneSound.Play();
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


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            keyTwoSound.Play();
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
            keyThreeSound.Play();
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
            spaceSound.Play();
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
            // FAILSAFE
            if(runeVal != 35 && runeVal != 37 && runeVal != 20 && runeVal != 10 && runeVal != 17 && runeVal != 11 && Input.GetKeyDown(KeyCode.Space))
            {
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
            // SUMMON TORCH GOBLIN / 1 + 2 + 3
            if (runeVal == 35 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                if(player.currentLevel >= 6)
                {
                    Instantiate(torchGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlThree, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlThree, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlFour, transform.position, transform.rotation);
                }
                else if(player.currentLevel >= 4)
                {
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlThree, transform.position, transform.rotation);
                }
                else if(player.currentLevel >= 2)
                {
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblinLvlTwo, transform.position, transform.rotation);
                }
                else if(player.currentLevel < 2)
                {
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                    Instantiate(torchGoblin, transform.position, transform.rotation);
                }
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
                if(player.currentLevel >= 5)
                {
                    Instantiate(TNTGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlThree, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlThree, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlFour, transform.position, transform.rotation);
                }
                else if(player.currentLevel >= 3)
                {
                    Instantiate(TNTGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlTwo, transform.position, transform.rotation);
                    Instantiate(TNTGoblinLvlThree, transform.position, transform.rotation);
                }
                else if(player.currentLevel >= 1)
                {
                Instantiate(TNTGoblin, transform.position, transform.rotation);
                Instantiate(TNTGoblin, transform.position, transform.rotation);
                Instantiate(TNTGoblinLvlTwo, transform.position, transform.rotation);
                }
                else if(player.currentLevel < 1)
                {
                Instantiate(TNTGoblin, transform.position, transform.rotation);
                Instantiate(TNTGoblin, transform.position, transform.rotation);
                Instantiate(TNTGoblin, transform.position, transform.rotation);
                }
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

        if (runeOne && runeTwo && runeThree)
        {
            // SUMMON BARREL GOBLIN / 2 + 1 + 3
            if (runeVal == 20 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                Instantiate(BarrelGoblin, transform.position, transform.rotation);
                Instantiate(BarrelGoblin, transform.position, transform.rotation);
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
                currentMana -= BarrelGoblinManaCost;
            }
        }

        if (runeOne && runeTwo && runeThree)
        {
            // REPLENISH HEALTH / 3 + 1 + 2
            if (runeVal == 17 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                player.playerCurrentHealth += 20f;
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
                currentMana -= BarrelGoblinManaCost;
            }
        }

        if (runeOne && runeTwo && runeThree)
        {
            // SPEED BOOST / 2 + 3 + 1
            if (runeVal == 10 && Input.GetKeyDown(KeyCode.Space) && currentMana >= 0)
            {
                player.moveSpeed += 5f;
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
                currentMana -= BarrelGoblinManaCost;
                Invoke("SetSpeedNormal", 1.5f);
            }
        }
        
        
    }

    private void SetSpeedNormal()
    {
        player.moveSpeed -= 5f;
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

    // 20  - SUMMON BARREL GOBLIN / 2 + 1 + 3

    // 10 - SPEED BOOST / 2 + 3 + 1 

    // 17 - REPLENISH HEALTH / 3 + 1 + 2

    // 11 - REPLENISH MANA / 3 + 2 + 1
    // SUMMON VALUES ----------------------
}

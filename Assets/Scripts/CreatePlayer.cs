using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour
{
    public InputField nameInput;
    public GameObject raceInput; //dropdown field
    public GameObject classInput; //dropdown field
    public GameObject alignmentInput; //dropdown field

    public Text displayDiceRollOne;
    public Text displayDiceRollTwo;
    public Text displayDiceRollThree;
    public Text displayDiceRollFour;
    public Text displayDiceRollFive;

    public Text strengthTextDisplay;
    public Text dexterityTextDisplay;
    public Text constitutionTextDisplay;
    public Text inteligenceTextDisplay;
    public Text wisdomTextDisplay;
    public Text charismaTextDisplay;

    public Text currXpTextDisplay;
    public Text maxXpTextDisplay;
    public Text currHpTextDisplay;
    public Text maxHpTextDisplay;
    public Text armorClassTextDisplay;
    public Text speedTextDisplay;
    public Text jumpTextDisplay;

    public string json;
    public InputField displayJsonText;

    public Player newPlayer;
    public List<int> playerAbilitiesTracker; //Used to prevent player from wasting memory by rolling more than 6 times

    void Start()
    {
        newPlayer = new Player();
        SetPlayerInfo();
    }
    public void IncreaseCurrXP()
    {
        newPlayer.currXP++;
        currXpTextDisplay.text = newPlayer.currXP.ToString();
    }
    public void DecreaseCurrXP()
    {
        newPlayer.currXP--;
        if (newPlayer.currXP < 0)
        {
            newPlayer.currXP = 0;
        }
        currXpTextDisplay.text = newPlayer.currXP.ToString();
    }
    public void IncreaseMaxXP()
    {
        newPlayer.maxXP++;
        maxXpTextDisplay.text = newPlayer.maxXP.ToString();
    }
    public void DecreaseMaxXP()
    {
        newPlayer.maxXP--;
        if (newPlayer.maxXP < 0)
        {
            newPlayer.maxXP = 0;
        }
        maxXpTextDisplay.text = newPlayer.maxXP.ToString();
    }
    public void IncreaseCurrHP()
    {
        newPlayer.currHP++;
        currHpTextDisplay.text = newPlayer.currHP.ToString();
    }
    public void DecreaseCurrHP()
    {
        newPlayer.currHP--;
        if (newPlayer.currHP < 0)
        {
            newPlayer.currHP = 0;
        }
        currHpTextDisplay.text = newPlayer.currHP.ToString();
    }
    public void IncreaseMaxHP()
    {
        newPlayer.maxHP++;
        maxHpTextDisplay.text = newPlayer.maxHP.ToString();
    }
    public void DecreaseMaxHP()
    {
        newPlayer.maxHP--;
        if (newPlayer.maxHP < 0)
        {
            newPlayer.maxHP = 0;
        }
        maxHpTextDisplay.text = newPlayer.maxHP.ToString();
    }
    public void IncreaseArmorClass()
    {
        newPlayer.armorClass++;
        armorClassTextDisplay.text = newPlayer.armorClass.ToString();
    }
    public void DecreaseAmorclass()
    {
        newPlayer.armorClass--;
        if (newPlayer.armorClass < 0)
        {
            newPlayer.armorClass = 0;
        }
        armorClassTextDisplay.text = newPlayer.armorClass.ToString();
    }
    public void IncreaseSpeed()
    {
        newPlayer.runSpeed++;
        newPlayer.walkSpeed = newPlayer.runSpeed - 1;
        speedTextDisplay.text = newPlayer.runSpeed.ToString();
    }
    public void DecreaseSpeed()
    {
        newPlayer.runSpeed--;
        newPlayer.walkSpeed = newPlayer.runSpeed - 1;
        if (newPlayer.runSpeed < 0)
        {
            newPlayer.runSpeed = 0;
            newPlayer.walkSpeed = 0;
        }
        speedTextDisplay.text = newPlayer.runSpeed.ToString();
    }
    public void IncreaseJump()
    {
        newPlayer.jumpHeight++;
        jumpTextDisplay.text = newPlayer.jumpHeight.ToString();
    }
    public void DecreaseJump()
    {
        newPlayer.jumpHeight--;
        if (newPlayer.jumpHeight < 0)
        {
            newPlayer.jumpHeight = 0;
        }
        jumpTextDisplay.text = newPlayer.jumpHeight.ToString();
    }


    public void RollDice()
    {
        System.Random r = new System.Random();
        int[] diceRolls = new int[5];
        for (int i = 0; i < diceRolls.Length; i++)
        {
            diceRolls[i] = r.Next(1, 7);
        }

        displayDiceRollOne.text = diceRolls[0].ToString();
        displayDiceRollTwo.text = diceRolls[1].ToString();
        displayDiceRollThree.text = diceRolls[2].ToString();
        displayDiceRollFour.text = diceRolls[3].ToString();
        displayDiceRollFive.text = diceRolls[4].ToString();

        Array.Sort(diceRolls);
        Array.Reverse(diceRolls);

        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += diceRolls[i];
        }
        if (playerAbilitiesTracker.Count < 7)
        {
            /*This block of code checks that the player has not rolled
             * more than 6 times in order to prevent uneccessary memory usage*/
            DisplaySum(sum);
        }
    }
    public void DisplaySum(int sum)
    {
        playerAbilitiesTracker.Add(sum);

        if (playerAbilitiesTracker.Count >= 1 && playerAbilitiesTracker.Count < 7)
        {
            newPlayer.strength = playerAbilitiesTracker[0];
            strengthTextDisplay.text = playerAbilitiesTracker[0].ToString();
        }
        if (playerAbilitiesTracker.Count >= 2 && playerAbilitiesTracker.Count < 7)
        {
            newPlayer.dexterity = playerAbilitiesTracker[1];
            dexterityTextDisplay.text = playerAbilitiesTracker[1].ToString();
        }
        if (playerAbilitiesTracker.Count >= 3 && playerAbilitiesTracker.Count < 7)
        {
            newPlayer.constitution = playerAbilitiesTracker[2];
            constitutionTextDisplay.text = playerAbilitiesTracker[2].ToString();
        }
        if (playerAbilitiesTracker.Count >= 4 && playerAbilitiesTracker.Count < 7)
        {
            newPlayer.inteligence = playerAbilitiesTracker[3];
            inteligenceTextDisplay.text = playerAbilitiesTracker[3].ToString();
        }
        if (playerAbilitiesTracker.Count >= 5 && playerAbilitiesTracker.Count < 7)
        {
            newPlayer.wisdom = playerAbilitiesTracker[4];
            wisdomTextDisplay.text = playerAbilitiesTracker[4].ToString();
        }
        if (playerAbilitiesTracker.Count == 6)
        {
            newPlayer.charisma = playerAbilitiesTracker[5];
            charismaTextDisplay.text = playerAbilitiesTracker[5].ToString();
        }
    }
    public void ResetAbilities()
    {
        playerAbilitiesTracker.Clear();
        newPlayer.strength = 0;
        strengthTextDisplay.text = "0";

        newPlayer.dexterity = 0;
        dexterityTextDisplay.text = "0";

        newPlayer.constitution = 0;
        constitutionTextDisplay.text = "0";

        newPlayer.inteligence = 0;
        inteligenceTextDisplay.text = "0";

        newPlayer.wisdom = 0;
        wisdomTextDisplay.text = "0";

        newPlayer.charisma = 0;
        charismaTextDisplay.text = "0";
    }
    public void ResetDices()
    {
        displayDiceRollOne.text = "1";
        displayDiceRollTwo.text = "2";
        displayDiceRollThree.text = "3";
        displayDiceRollFour.text = "4";
        displayDiceRollFive.text = "5";
    }

    public void SetPlayerInfo()
    {
        newPlayer.name = nameInput.text;
        newPlayer.race = raceInput.GetComponent<Text>().text;
        newPlayer.clss = classInput.GetComponent<Text>().text;
        newPlayer.alignment = alignmentInput.GetComponent<Text>().text;

        newPlayer.abilities["Strength"] = newPlayer.strength;
        newPlayer.abilities["Dexterity"] = newPlayer.dexterity;
        newPlayer.abilities["Constitution"] = newPlayer.constitution;
        newPlayer.abilities["Inteligence"] = newPlayer.inteligence;
        newPlayer.abilities["Wisdom"] = newPlayer.wisdom;
        newPlayer.abilities["Charisma"] = newPlayer.charisma;
    }
    public void DisplayJson()
    {
        json = JsonUtility.ToJson(newPlayer);
        displayJsonText.text = json;
    }
    
}
public class Player
{
    //Basic player info
    public string name;
    public Dictionary<string, int> abilities = new Dictionary<string, int>();
    public string race;
    public string clss;
    public string alignment;

    //Player abilities
    public int strength = 0;
    public int dexterity = 0;
    public int constitution = 0;
    public int inteligence = 0;
    public int wisdom = 0;
    public int charisma = 0;

    //Player ability modifiers
    public int strengthMod = 2;
    public int dexterityMod = 2;
    public int constitutionMod = 2;
    public int inteligenceMod = 2;
    public int wisdomMod = 2;
    public int charismaMod = 2;

    //Player skills
    public int acrobatics = 2;
    public int aniHand = 2;
    public int arcana = 2;
    public int athletics = 2;
    public int deception = 2;
    public int history = 2;
    public int insight = 2;
    public int intim = 2;
    public int invest = 2;
    public int medicine = 2;
    public int nature = 2;
    public int perception = 2;
    public int performance = 2;
    public int persuasion = 2;
    public int religion = 2;
    public int sleightOfHand = 2;
    public int stealth = 2;
    public int sruvival = 2;

    //Player stats
    public int currXP, maxXP;
    public int currHP, maxHP;
    public int armorClass;
    public int walkSpeed, runSpeed, jumpHeight;

    //Other
    public List<String> itemList;
}



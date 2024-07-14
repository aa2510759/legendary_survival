using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentStatPickUp : MonoBehaviour
{
    [Header("Type of PickUp")]
    public bool maxHealth = false;
    public bool health = false;
    public bool hunger = false;
    public bool speed = false;
    public bool defense = false;
    public bool attack = false;
    public bool gold = false;



    [Header("Increase Amount")]

    public int MaxHp = 0;
    public int Hp = 0;
    public int Food = 0;
    public int Sp = 0;
    public int Def = 0;
    public int Atk = 0;
    public int money = 0;

    public void IncreaseMaxHPStat()
    {
        CharacterManager.maxHP += MaxHp;

    }

    public void IncreaseHPStat()
    {
        if (CharacterManager.maxHP < CharacterManager.hp + Hp)
        {
            CharacterManager.hp = CharacterManager.maxHP;
        }

    }

    public void IncreaseHungerStat()
    {
        CharacterManager.hunger += Food;
    }

    public void IncreaseSpeedStat()
    {
        CharacterManager.speed += Sp;
    }

    public void IncreaseDefenseStat()
    {
        CharacterManager.defense += Def;
    }

    public void IncreaseAttackStat()
    {
        CharacterManager.attack += Atk;
    }

    public void IncreaseGoldAmount()
    {
        CharacterManager.gold += money;
    }

    public void TypeCheck()
    {
        if (health == true)
        {
            IncreaseHPStat();
        }
        else if (hunger == true)
        {
            IncreaseHungerStat();
        }
        else if (speed == true)
        {
            IncreaseSpeedStat();
        }
        else if (defense == true)
        {
            IncreaseDefenseStat();
        }
        else if (attack == true)
        {
            IncreaseAttackStat();
        }
        else if (gold == true)
        {
            IncreaseGoldAmount();
        }
    }

    void OnTriggerEnter2D()
    {

        TypeCheck();
        Destroy(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PermanentStatPickUp : MonoBehaviour
{
    public GunSelection gunUI;

    public void Start()
    {
        gunUI = GameObject.Find("Canvas").GetComponent<GunSelection>();
    }

    [Header("Type of PickUp")]
    public bool maxHealth = false;
    public bool health = false;
    public bool hunger = false;
    public bool speed = false;
    public bool defense = false;
    public bool attack = false;
    public bool gold = false;

    public bool weapon = false;

     

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

    public void addWeaponToInventory(GunScript gunData)
    {
      //  print(CharacterManager.instance.weaponInventory.Count);
      //  CharacterManager.instance.weaponInventory.Add(this.gameObject.GetComponent<GunScript>());
       // print(CharacterManager.instance.weaponInventory.Count);

        for(int i = 0; CharacterManager.instance.weaponInventory.Length > i; i++)
        {
            if (CharacterManager.instance.weaponInventory[i] != null)
            {
                print("This slot is taken");
                print(CharacterManager.instance.weaponInventory[i].gunName);
            }
            else if (CharacterManager.instance.weaponInventory[i] == null)
            {
                print("Found a free slot");
                CharacterManager.instance.weaponInventory[i] = gunData;
                gunUI.weaponSlotImages[i].sprite = CharacterManager.instance.weaponInventory[i].gunSprite.sprite;
                break ;
            }
            else
            {
                print("dis dont work inventory is full sorry");
            }
            
        }
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
        else if(weapon == true)
        {
       //     addWeaponToInventory();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player")  )
        {

             
            if (weapon == true)
            {
                if (CharacterManager.instance.weaponInventory[0] != null && CharacterManager.instance.weaponInventory[1] != null
                    && CharacterManager.instance.weaponInventory[2] != null && CharacterManager.instance.weaponInventory[3] != null)
                {
                    print("Sorry but your inventory is full so you cant pick this up");
                }
                else
                {
                    GameObject newWeapon = Instantiate(this.gameObject);
                    newWeapon.GetComponent<BoxCollider2D>().enabled = false;
                    newWeapon.GetComponent<SpriteRenderer>().enabled = false;
                    newWeapon.transform.SetParent(GameObject.Find("CharacterManager").transform);
                    addWeaponToInventory(newWeapon.GetComponent<GunScript>());
                    Destroy(gameObject);
                }
                 
            }
            else
            {
                TypeCheck();
                Destroy(gameObject);
            }
            
        }

        
    }

   


}

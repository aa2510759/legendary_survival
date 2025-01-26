using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSelection : MonoBehaviour
{
    public GameObject[] weaponSlotButtons;

    public Image[] weaponSlotImages;

    public CharacterShoot charShoot;

    public TMP_Text[] gunNameInv;

    public TMP_Text[] gunAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        

        charShoot = GameObject.Find("Character").GetComponent<CharacterShoot>();
        for (int i = 0; CharacterManager.instance.weaponInventory.Length > i; i++)
        {
            if(CharacterManager.instance.weaponInventory[i] == null)
            {
                break;
            }
            print(CharacterManager.instance.weaponInventory[i].gunSprite.sprite);
                weaponSlotImages[i].sprite = CharacterManager.instance.weaponInventory[i].gunSprite.sprite;
               
            
            
        }

       // if(charShoot.gunEquipped == true && charShoot.currentGun != null)
     //   {

     //   }
    }

    // Update is called once per frames
    void Update()
    {
        for(int i =0; gunNameInv.Length > i; i++)
        {
            if(charShoot.charManager.weaponInventory[i] != null)
            {
                weaponSlotImages[i].sprite = charShoot.charManager.weaponInventory[i].GetComponent<SpriteRenderer>().sprite;
                gunNameInv[i].text = charShoot.charManager.weaponInventory[i].gunName;
                gunAmmoText[i].text = "Ammo: " + charShoot.charManager.weaponInventory[i].Ammo;
            }
            else
            {
            //    print("No weapon found at this inventory slot. The text has not been set in this slot");
            }
             
        }
    }

    public void EquipWeapon_1()
    {
        if (CharacterManager.instance.weaponInventory[0] != null)
        {
            CharacterManager.instance.currentState = CharacterManager.slotEquipped.Slot_1;
            charShoot.charManager.gunEquipped = true;
            charShoot.charManager.currentGun = CharacterManager.instance.weaponInventory[0].GetComponent<GunScript>();
        }
        else
        {
            charShoot.charManager.gunEquipped = false;
            charShoot.charManager.currentGun = null;
        }
             
        GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = weaponSlotImages[0].sprite;
    }
    public void EquipWeapon_2()
    {
        if (CharacterManager.instance.weaponInventory[1] != null)
        {
            CharacterManager.instance.currentState = CharacterManager.slotEquipped.Slot_2;
            charShoot.charManager.gunEquipped = true;
            charShoot.charManager.currentGun = CharacterManager.instance.weaponInventory[1].GetComponent<GunScript>();
        }
        else
        {
            charShoot.charManager.gunEquipped = false;
            charShoot.charManager.currentGun = null;
        }

       
        GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = weaponSlotImages[1].sprite;
    }
    public void EquipWeapon_3()
    {
        if (CharacterManager.instance.weaponInventory[2] != null)
        {
            CharacterManager.instance.currentState = CharacterManager.slotEquipped.Slot_3;
            charShoot.charManager.gunEquipped = true;
            charShoot.charManager.currentGun = CharacterManager.instance.weaponInventory[2].GetComponent<GunScript>();
        }
        else
        {
            charShoot.charManager.gunEquipped = false;
            charShoot.charManager.currentGun = null;
        }

         
        GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = weaponSlotImages[2].sprite;
    }
    public void EquipWeapon_4()
    {
        if (CharacterManager.instance.weaponInventory[3] != null)
        {
            CharacterManager.instance.currentState = CharacterManager.slotEquipped.Slot_4;
            charShoot.charManager.gunEquipped = true;
            charShoot.charManager.currentGun = CharacterManager.instance.weaponInventory[3].GetComponent<GunScript>();
        }
        else
        {
            charShoot.charManager.gunEquipped = false;
            charShoot.charManager.currentGun = null;
        }
       
        GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = weaponSlotImages[3].sprite;
    }
}

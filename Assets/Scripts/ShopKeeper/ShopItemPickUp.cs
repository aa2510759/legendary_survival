using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemPickUp : MonoBehaviour
{

    public bool inCollider;

    public int itemPrice;

    public string collidedObjectName;

    public ShopKeeper shop_Keeper;
  //  public CharacterManager characterManager;
    // Start is called before the first frame update
    void Start()
    {
        shop_Keeper = GameObject.Find("ShopKeeper").GetComponent<ShopKeeper>();
        //    characterManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inCollider == true)
        {
            Debug.Log("E key was pressed!");

            if(itemPrice <= CharacterManager.gold)
            {
                print("Item was bought");
                string boughtItemStr = this.gameObject.name;
                string numberString = boughtItemStr.Substring(boughtItemStr.IndexOf('_') + 1);
                int itemNumber = int.Parse(numberString);
                int arrayIndex = itemNumber - 1;

                 
                 
                if(shop_Keeper.shopItems[arrayIndex].GetComponent<PermanentStatPickUp>().weapon == true)
                {
                    int fullInventoryChecker = 0;
                    for(int i = 0; CharacterManager.instance.weaponInventory.Length > i; i++)
                    {
                        if(CharacterManager.instance.weaponInventory[i] == null)
                        {
                            print("Found a free slot for the shop item :)");
                        }
                        else
                        {
                            fullInventoryChecker++;
                        }
                        
                    }
                    if (fullInventoryChecker == 4)
                    {
                        print("Sorry but 4 full inventory slots were found so you cannot purchase this item :(");
                        return;
                    }
                }

                    CharacterManager.gold = CharacterManager.gold - itemPrice;
                    if (GameObject.Find("Item_1") != null && collidedObjectName == GameObject.Find("Item_1").name )
                    {
                        print(shop_Keeper.shopItems[0].name);
                        GiveItem(shop_Keeper.shopItems[0], 0);

                    }
                    else if (GameObject.Find("Item_2") != null && collidedObjectName == GameObject.Find("Item_2").name)
                    {
                        print(shop_Keeper.shopItems[1].name);
                        GiveItem(shop_Keeper.shopItems[1], 1);
                    }
                    else if (GameObject.Find("Item_3") != null && collidedObjectName == GameObject.Find("Item_3").name)
                    {
                        print(shop_Keeper.shopItems[2].name);
                        GiveItem(shop_Keeper.shopItems[2], 2);
                    }
                    print("New gold amount is : " + CharacterManager.gold);
                    Destroy(this.gameObject);
                 
            }
        }
    }

    public void GiveItem(GameObject obj, int shopSlot)
    {

        if (obj.GetComponent<PermanentStatPickUp>().weapon == true)
        {
            if (CharacterManager.instance.weaponInventory[0] != null && CharacterManager.instance.weaponInventory[1] != null
                && CharacterManager.instance.weaponInventory[2] != null && CharacterManager.instance.weaponInventory[3] != null)
            {
                print("Sorry but your inventory is full so you cant pick this up");
            }
            else
            {
                GameObject newWeapon = Instantiate(shop_Keeper.shopItems[shopSlot]);
                newWeapon.GetComponent<BoxCollider2D>().enabled = false;
                newWeapon.GetComponent<SpriteRenderer>().enabled = false;
                newWeapon.transform.SetParent(GameObject.Find("CharacterManager").transform);
                obj.GetComponent<PermanentStatPickUp>().addWeaponToInventory(newWeapon.GetComponent<GunScript>());
                
            }
        }
        else
        {
            obj.GetComponent<PermanentStatPickUp>().TypeCheck();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        collidedObjectName = this.gameObject.name;
        inCollider = true;
        

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        inCollider = false;


    }
}

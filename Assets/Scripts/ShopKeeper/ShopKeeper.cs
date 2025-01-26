using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ShopKeeper : MonoBehaviour
{
    public GameObject[] shopItems;
    private string currentItemName;



    public GameObject[] listOfPossibleItems;
    // Start is called before the first frame update
    void Start()
    {
        int itemID = 0;
       for(int i = 0; shopItems.Length > i; i++)
        {
            itemID++;
            currentItemName = "Item_" + (itemID);

            
            //  print("BRUHB HBURHB" + (listOfPossibleItems.Length - 1));
            // print(Random.Range(0, listOfPossibleItems.Length));

           int generatednumber = Random.Range(0, (listOfPossibleItems.Length));
            shopItems[i] = listOfPossibleItems[generatednumber];
            GameObject.Find(currentItemName).GetComponent<SpriteRenderer>().sprite = shopItems[i].GetComponent<SpriteRenderer>().sprite;

             if(shopItems[i].GetComponent<SpriteRenderer>().name == "ShotGun")
            {
                GameObject.Find("Item_" + itemID).GetComponent<ShopItemPickUp>().itemPrice = 30;
            }
             else if(shopItems[i].GetComponent<SpriteRenderer>().name == "Pistol")
            {
                GameObject.Find("Item_" + itemID).GetComponent<ShopItemPickUp>().itemPrice = 15;
            }
             else if(shopItems[i].GetComponent<SpriteRenderer>().name == "apple")
            {
                GameObject.Find("Item_" + itemID).GetComponent<ShopItemPickUp>().itemPrice = 5;
            }

            GameObject.Find("Item_" + itemID + "_Text").GetComponent<TextMeshPro>().text = shopItems[i].name;
            GameObject.Find("ItemCost_" + itemID + "_Text").GetComponent<TextMeshPro>().text = "$: " + GameObject.Find("Item_" + itemID).GetComponent<ShopItemPickUp>().itemPrice;
            print("CURRENT SPRITE " + shopItems[i].GetComponent<SpriteRenderer>().sprite);
            //*Testing some cool ass shit
            //currentItemName = "Item_" + (i + 1);
            // shopItems[i] = GameObject.Find(currentItemName);


        }
    }

    
}

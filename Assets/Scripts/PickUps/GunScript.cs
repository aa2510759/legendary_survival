using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    
    public string gunName;
    public int Ammo;
    public SpriteRenderer gunSprite;



    // Start is called before the first frame update
    void Start()
    {
        gunSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void ReduceBulletCount(int removalAmount)
    {
        Ammo = Ammo - removalAmount;
    }

    public void AmmoFound(int ammoAmount)
    {
        //FUNCTION FOR WHEN PLAYER FINDS AMMO FOR THEIR WEAPON!!! WIP
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

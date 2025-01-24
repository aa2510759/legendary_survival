using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;

    public SpriteRenderer currentGunSprite;
    public CharacterControls control;

    public CharacterManager charManager;

    public void Start()
    {
        print("AYE CHARACTERSHOOT JUST RAN");
        charManager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();

        if(CharacterManager.instance.currentState == CharacterManager.slotEquipped.Slot_1 && charManager.gunEquipped == true && GameObject.Find("Canvas").GetComponent<GunSelection>().weaponSlotImages[0].sprite != null)
        {
            currentGunSprite.sprite = GameObject.Find("Canvas").GetComponent<GunSelection>().weaponSlotImages[0].sprite;

            GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = currentGunSprite.sprite;
        }
        else if(CharacterManager.instance.currentState == CharacterManager.slotEquipped.Slot_2 && charManager.gunEquipped == true)
        {
            currentGunSprite.sprite = GameObject.Find("Canvas").GetComponent<GunSelection>().weaponSlotImages[1].sprite;

            GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = currentGunSprite.sprite;
        }
        else if(CharacterManager.instance.currentState == CharacterManager.slotEquipped.Slot_3 && charManager.gunEquipped == true)
        {
            currentGunSprite.sprite = GameObject.Find("Canvas").GetComponent<GunSelection>().weaponSlotImages[2].sprite;

            GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = currentGunSprite.sprite;
        }
        else if(CharacterManager.instance.currentState == CharacterManager.slotEquipped.Slot_4 && charManager.gunEquipped == true)
        {
            currentGunSprite.sprite = GameObject.Find("Canvas").GetComponent<GunSelection>().weaponSlotImages[3].sprite;

            GameObject.Find("ShootPoint").GetComponent<SpriteRenderer>().sprite = currentGunSprite.sprite;
        }
    }

    public void Shoot()
    {
        if (charManager.gunEquipped == true && charManager.currentGun != null)
        {

            if (CharacterManager.instance.currentGun != null && CharacterManager.instance.currentGun.Ammo > 0)
            {
                CharacterManager.instance.currentGun.ReduceBulletCount(1);


                if (charManager.currentGun.gunName == "ShotGun")
                {
                     
                    // Spread parameters
                    int numberOfProjectiles = 3; // Number of bullets in the spread
                    float spreadAngle = 15f;     // Total angle of the spread

                    // Determine the base direction and flip the angle if shooting left
                    bool isShootingLeft = control.leftBulletForce;
                    Vector2 baseDirection = isShootingLeft ? -shootPoint.right : shootPoint.right;

                    for (int i = 0; i < numberOfProjectiles; i++)
                    {
                        // Calculate the angle offset for this bullet
                        float angleStep = spreadAngle / (numberOfProjectiles - 1); // Step size between bullets
                        float angleOffset = -spreadAngle / 2 + (i * angleStep);    // Offset from center

                        // Flip the angle for left shooting
                        if (isShootingLeft)
                        {
                            angleOffset = -angleOffset;
                        }

                        // Rotate the base direction by the calculated angle
                        Vector2 shootDirection = Quaternion.Euler(0, 0, angleOffset) * baseDirection;

                        // Create the projectile
                        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

                        // Apply force to the projectile
                        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                        if (rb != null)
                        {
                            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
                        }
                    }
                }
                else if (charManager.currentGun.gunName == "Pistol")
                {
                    GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        if (control.leftBulletForce == true)
                        {
                            rb.AddForce(-shootPoint.right * shootForce, ForceMode2D.Impulse);
                        }
                        else if (control.rightBulletForce == true)
                        {
                            rb.AddForce(shootPoint.right * shootForce, ForceMode2D.Impulse);
                        }

                    }
                    //***Scrapped code for now 
                    /*else if (control.downBulletForce == true)
                    {
                        rb.AddForce(-shootPoint.up * shootForce, ForceMode2D.Impulse);
                    }
                    else if (control.upBulletForce == true)
                    {
                        rb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
                    }
                    */

                }
                else
                {
                    print("Sorry but you dont have a gun equipped fucking loser");
                }
                //   }
                //  else
                //  {
                //     print("You haven't picked up a gun yet so you can shoot sorry :(");
            }
        }
        
    }
}

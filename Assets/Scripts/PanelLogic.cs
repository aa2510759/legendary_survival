using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLogic : MonoBehaviour
{
    public Text displayHp;
    public Text displayHunger;
    public Text displayAttack;
    public Text displayDefense;
    public Text displaySpeed;
    public Text displayGold;

    void Update()
    {
        if (displayHp != null ||
        displayHunger != null ||
        displayAttack != null ||
        displayDefense != null ||
        displaySpeed != null ||
        displayGold != null)
        {
            float hp = VariableManager.hp;
            float hunger = VariableManager.hunger;
            float attack = VariableManager.attack;
            float defense = VariableManager.defense;
            float speed = VariableManager.speed;
            float gold = VariableManager.gold;
            displayHp.text = "hp: " + hp.ToString();
            displayHunger.text = "hunger: " + hunger.ToString();
            displayAttack.text = "attack: " + attack.ToString();
            displayDefense.text = "defense: " + defense.ToString();
            displaySpeed.text = "speed: " + speed.ToString();
            displayGold.text = "gold: " + gold.ToString();
        }
    }
}

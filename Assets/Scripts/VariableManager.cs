using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private string name;
    private string character;
    private int hp;
    private int hunger;
    private int attack;
    private int speed;
    private int defense;
    private int gold;

    // Class methods
    public void setName(string name) { this.name = name; }
    public string getName() { return name; }
    public void setCharacter(string character) { this.character = character; }
    public string getCharacter() { return character; }

    public void setHp(int hp) { this.hp = hp; }
    public int getHp() { return hp; }
    public void setHunger(int hunger) { this.hunger = hunger; }
    public int getHunger() { return hunger; }
    public void setAttack(int attack) { this.attack = attack; }
    public int getAttack() { return attack; }
    public void setDefense(int defense) { this.defense = defense; }
    public int getDefense() { return defense; }
    public void setSpeed(int speed) { this.speed = speed; }
    public int getSpeed() { return speed; }
    public void setGold(int gold) { this.gold = gold; }
    public int getGold() { return gold; }

    public Player(string name, string character, int hp, int hunger, int attack, int defense, int speed, int gold)
    {
        this.name = name;
        this.character = character;
        this.hunger = hunger;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.gold = gold;
    }
}
public class VariableManager : MonoBehaviour
{
    public static VariableManager instance;

    Player Hunter = new Player("", "Hunter", 80, 80, 80, 80, 80, 80);
    Player Mercenary = new Player("", "Mercenary", 90, 90, 90, 90, 90, 90);

    Player Cop = new Player("", "Cop", 70, 70, 70, 70, 70, 70);


    // Start is called before the first frame update


    public static string spriteChoice;
    public static float hp = 100;


    public static float hunger = 10;


    public static float speed = 80;

    public static float defense = 70;


    public static float attack = 60;

    public static float gold = 50;


    public static float x = 0;
    public static float y = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    void Start()
    {
        if (buttonSpriteChanger.spriteTag == "Hunter")
        {
            spriteChoice = buttonSpriteChanger.spriteTag;
            hp = Hunter.getHp();
            attack = Hunter.getAttack();
            defense = Hunter.getDefense();
            speed = Hunter.getSpeed();
            gold = Hunter.getGold();
            hunger = Hunter.getHunger();
        }

        if (buttonSpriteChanger.spriteTag == "Mercenary")
        {
            spriteChoice = buttonSpriteChanger.spriteTag;
            hp = Mercenary.getHp();
            attack = Mercenary.getAttack();
            defense = Mercenary.getDefense();
            speed = Mercenary.getSpeed();
            gold = Mercenary.getGold();
            hunger = Mercenary.getHunger();
        }

        if (buttonSpriteChanger.spriteTag == "Cop")
        {
            spriteChoice = buttonSpriteChanger.spriteTag;
            hp = Cop.getHp();
            attack = Cop.getAttack();
            defense = Cop.getDefense();
            speed = Cop.getSpeed();
            gold = Cop.getGold();
            hunger = Cop.getHunger();
        }
    }
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
    }
}

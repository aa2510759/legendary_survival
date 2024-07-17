using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player
{
    private string name;
    private string character;
    private int maxHp;
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

    public void setMaxHp(int maxHp) { this.maxHp = maxHp; }
    public int getMaxHp() { return maxHp; }
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

    public Player(string name, string character, int maxHp, int hp, int hunger, int attack, int defense, int speed, int gold)
    {
        this.name = name;
        this.character = character;
        this.maxHp = maxHp;
        this.hunger = hunger;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.gold = gold;
    }
}
public class CharacterManager : MonoBehaviour
{
    public static int daysPassed = 0; //making it static and public so we can access it from other scripts

    public static CharacterManager instance;

    Player Hunter = new Player("", "Hunter", 200, 80, 50, 80, 80, 80, 80);
    Player Mercenary = new Player("", "Mercenary", 150, 90, 50, 90, 90, 90, 90);
    Player Cop = new Player("", "Cop", 175, 70, 50, 70, 70, 70, 70);

    public static string spriteChoice;
    public static float maxHP = 100;
    public static float hp = 100;
    public static float hunger = 10;
    public static float speed = 80;
    public static float defense = 70;
    public static float attack = 60;
    public static float gold = 50;
    public static float x = 0;
    public static float y = 0;

    void decideClass()
    {
        List<Player> Classes = new List<Player>() { Hunter, Mercenary, Cop };
        var totalClasses = Classes.Count;
        for (int i = 0; i < totalClasses; i++)
        {
            if (buttonSpriteChanger.spriteTag == Classes[i].getCharacter())
            {
                hp = Classes[i].getHp();
                attack = Classes[i].getAttack();
                defense = Classes[i].getDefense();
                speed = Classes[i].getSpeed();
                gold = Classes[i].getGold();
                hunger = Classes[i].getHunger();
            }

        }
    }

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

        spriteChoice = buttonSpriteChanger.spriteTag;
        decideClass();
    }
    void Update()
    {

        x = transform.position.x;
        y = transform.position.y;
    }
}

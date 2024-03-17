 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



class StoryBlock
{
    public string eventStory;
    public string option1Text;
    public string option2Text;
    public StoryBlock option1Block;
    public StoryBlock option2Block;

 public StoryBlock(string story, string option1Text = "", string option2Text = "", StoryBlock option1Block = null, StoryBlock option2Block = null)
  {
        this.eventStory = story;
        this.option1Text = option1Text;
        this.option2Text = option2Text;
        this.option1Block = option1Block;
          this.option2Block = option2Block;
 }

}

public class EncounterManager : MonoBehaviour
{
    public GameObject mainUI;
    public Text mainText;
    public Button option1;
    public Button option2;

    public bool hasHappen = false;

    StoryBlock currentBlock;


    // Start is called before the first frame update


   


    static StoryBlock block5 = new StoryBlock("INCORRECT NOT BASED", "exit", "exit");
    static StoryBlock block4 = new StoryBlock("CORRECT YOU ARE AMAZING!","exit", "exit");
    static StoryBlock block3 = new StoryBlock("I am quagmire", "Your kinda creepy man", "Your kinda BASED BRO!!!", block5, block4);
    static StoryBlock block2 = new StoryBlock("I am peter griffin", "Are you from family guy?", "Are you from fortnite?", block4, block5);
    static StoryBlock block1 = new StoryBlock("Yo wanna meet peter griffin or Quagmire?", "PETER GRIFFIN", "QUAGMIRE", block2, block3);

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHappen == false)
        {
            hasHappen = true;
            mainUI.SetActive(true);
            DisplayBlock(block1);
        }
    }

    void DisplayBlock(StoryBlock block)
    {
        
        mainText.text = block.eventStory;
        option1.GetComponentInChildren<Text>().text = block.option1Text;
        option2.GetComponentInChildren<Text>().text = block.option2Text;

        currentBlock = block;
    }


   public  void Encounter_One_Clicked()
    {
        if(option1.GetComponentInChildren<Text>().text == "exit")
        {
            mainUI.SetActive(false);
            return;
        }
        DisplayBlock(currentBlock.option1Block);
       
    }

    public void Encounter_Two_Clicked()
    {
        if (option1.GetComponentInChildren<Text>().text == "exit")
        {
            mainUI.SetActive(false);
        }
        DisplayBlock(currentBlock.option2Block);
    }

   
}
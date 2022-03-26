using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    public List<GameObject> choiceBoxes;
    public Choice choice;
    public float distance = 3f;

    public bool multipleChoice = false;
    bool triggerChoiceBoxes = false;

    void Update()
    {
        if (Vector3.Distance(transform.position, FindObjectOfType<PlayerController>().transform.position) <= distance)
        {
            if (Input.GetButtonDown("Submit")) // Change key the interact(chat) through project settings
            {
                if (!multipleChoice)
                    trigger.TriggerDialogue();
                else
                {
                    trigger.TriggerDialogue();
                    triggerChoiceBoxes = true;
                }
            }
        }

        if (!DialogueManager.isActive && multipleChoice && triggerChoiceBoxes)
        {
            int index = 0;
            foreach (GameObject choiceBox in choiceBoxes)
            {
                choiceBox.SetActive(true);
                choiceBox.GetComponentInChildren<Text>().text = choice.choices[index];
                index++;
            }
        }

    }

    public void SetLine(Button button)
    {
        var buttonText = button.GetComponentInChildren<Text>();
        if (buttonText.text.Contains("Leave"))
        {
            choice.triggerTwo.TriggerDialogue();
        }
        else
        {
            choice.triggerOne.TriggerDialogue();
        }
        foreach (GameObject choiceBox in choiceBoxes)
        {
            choiceBox.SetActive(false);
        }
        triggerChoiceBoxes = false;
    }

}

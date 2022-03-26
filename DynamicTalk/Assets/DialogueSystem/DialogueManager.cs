using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text characterName;
    public Text lineText;
    float seconds;

    List<Line> currentLines;
    List<Character> currentCharacters;
    int activeLine = 0;
    public static bool isActive = false;

    public void OpenDialogue(List<Line> lines, List<Character> characters, float seconds)
    {
        dialogueBox.SetActive(true);
        currentLines = lines;
        currentCharacters = characters;
        activeLine = 0;
        this.seconds = seconds;
        isActive = true;
        DisplayLine();
    }

    public void DisplayLine()
    {
        Line linesToDisplay = currentLines[activeLine];
        lineText.text = linesToDisplay.line;
        StartCoroutine(NextLine());
        Character characterToDisplay = currentCharacters[linesToDisplay.characterID];
        characterName.text = characterToDisplay.name;
    }

    IEnumerator NextLine()
    {
        activeLine++;
        yield return new WaitForSeconds(seconds);
        if (activeLine < currentLines.Count)
        {
            DisplayLine();
        }
        else
        {
            isActive = false;
            dialogueBox.SetActive(false);
        }
    }

}

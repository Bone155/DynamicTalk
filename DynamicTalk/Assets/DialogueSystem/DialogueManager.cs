using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text characterName;
    public Text lineText;
    float seconds;

    Lines[] currentLines;
    Character[] currentCharacters;
    int activeLine = 0;
    public static bool isActive = false;

    public void OpenDialogue(Lines[] lines, Character[] characters, float seconds)
    {
        currentLines = lines;
        currentCharacters = characters;
        activeLine = 0;
        this.seconds = seconds;
        isActive = true;
        DisplayLine();
    }

    public void DisplayLine()
    {
        Lines linesToDisplay = currentLines[activeLine];
        lineText.text = linesToDisplay.line;
        StartCoroutine(NextLine());
        Character characterToDisplay = currentCharacters[linesToDisplay.characterID];
        characterName.text = characterToDisplay.name;
    }

    IEnumerator NextLine()
    {
        activeLine++;
        yield return new WaitForSeconds(seconds);
        if (activeLine < currentLines.Length)
        {
            DisplayLine();
        }
        else
        {
            isActive = false;
        }
    }

}

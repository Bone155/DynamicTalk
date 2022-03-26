using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Line> lines;
    public List<Character> characters;
    [Tooltip("Seconds to read each line")]
    public float seconds;
    [HideInInspector] public DialogueManager manager;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        manager.OpenDialogue(lines, characters, seconds);
    }

}

[System.Serializable]
public class Line
{
    public int characterID;
    [TextArea(3, 10)]
    public string line;

    public Line() { }
    public Line(string line)
    {
        this.line = line;
    }
}

[System.Serializable]
public class Character
{
    public string name;
}

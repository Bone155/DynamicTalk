using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.isActive)
        {
            dialogueBox.SetActive(false);
        }
    }
}

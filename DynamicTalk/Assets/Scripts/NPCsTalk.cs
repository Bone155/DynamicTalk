using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsTalk : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject[] npcs;
    public float distance = 3f;

    bool canTalk = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(npcs[0].transform.position, npcs[1].transform.position) <= distance && canTalk)
        {
            trigger.TriggerDialogue();
            GameManager.instance.dialogueBox.gameObject.SetActive(true);
            if (!DialogueManager.isActive)
            {
                canTalk = false;
                GameManager.instance.dialogueBox.gameObject.SetActive(false);
            }
        }
        else
        {
            canTalk = true;
        }
    }

}

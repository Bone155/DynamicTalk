using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    public float distance = 3f;

    void Update()
    {
        if (Vector3.Distance(transform.position, FindObjectOfType<PlayerController>().transform.position) <= distance)
        {
            if (Input.GetButtonDown("Submit")) // Change key the interact(chat) through project settings
            {
                GameManager.instance.dialogueBox.gameObject.SetActive(true);
                trigger.TriggerDialogue();
            }
        }

    }

}

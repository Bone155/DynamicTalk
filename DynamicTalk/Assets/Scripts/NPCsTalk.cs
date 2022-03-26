using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsTalk : MonoBehaviour
{
    public DialogueTrigger trigger;
    public Transform target;
    public float distance = 3f;

    Vector3 direction;
    bool doneTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        if (doneTalking)
        {
            return;
        }

        direction = (transform.position - target.position) * -1;

        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            trigger.TriggerDialogue();
            doneTalking = true;
        }

        transform.Translate(direction * Time.deltaTime);
    }

}

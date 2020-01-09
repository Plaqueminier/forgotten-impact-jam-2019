using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int isUse = 0;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUse == 0 && collision.gameObject.layer == 8) {
            TriggerDialogue();
            isUse = 1;
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

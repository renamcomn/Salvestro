using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetTexts();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit) {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetTexts() {
        for(int i = 0; i < dialogue.dialogues.Count; i ++) {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if(hit != null) {
            Debug.Log("entrou na area de colisao");
            playerHit = true;
        } else {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}

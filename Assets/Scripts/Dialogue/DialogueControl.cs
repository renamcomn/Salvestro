using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; //Janela do dialogo
    public Image profileSprite; //sprite do perfil
    public TMP_Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    [HideInInspector] public bool isShowing;
    private int index;
    private string[] sentences;

    public static DialogueControl instance;

    // awake eh chamado antes de todos os Start()
    private void Awake() {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence() {
        foreach(char letter in sentences[index].ToCharArray()) {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para proxima fala.
    public void NextSentence() {
        if(speechText.text == sentences[index]) {
            if(index < sentences.Length - 1) {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            } else {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc.
    public void Speech(string[] txt) {
        if(!isShowing) {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    //FIFO - First in, First out. Contains the sentences to show for the dialogue.
    private Queue<string> sentences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
    }

    //Starts the dialogue for this screen.
    public void StartDialogue (Dialogue dialogue){
        nameText.text = dialogue.name;

        sentences.Clear();

        //Goes through each sentence in the "Dialogue" object that calls this function.
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);    //Put all sentences into the queue.
        }

        //Show the next sentence in the queue.
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //If there are no more sentences...
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        Debug.Log("End of convo");
    }
}

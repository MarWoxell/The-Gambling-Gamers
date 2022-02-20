using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Skrivet av Markus
public class InfoManager : MonoBehaviour
{
    public SaveData save;

    public Text StoryText;


    // Queue använder fifo (Först in, först ut)
    private Queue<string> Sentences;

    // lägger dit alla meningar man har skrivit
    void Start()
    {
        Sentences = new Queue<string>();
    }

    // en funkion som gör att texten börjar 
    public void StartStory(InfoDump dialogue)
    {
        // clearar meningen efter den har blivit använd
        Sentences.Clear();

        foreach (string Sentence in dialogue.Sentences)
        {
            Sentences.Enqueue(Sentence);
        }


        DisplayNextSentence();
    }


    // Visar nästa mening
    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string Sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Sentence));
    }

    // gör att en bokstav skrivs itaget istället för att skriva allt direkt
    IEnumerator TypeSentence(string Sentence)
    {
        StoryText.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            StoryText.text += letter;

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    // kollar ifall man är i menyn eller huben när dialogen är klar och laddar olika scener beroende på vilken man är i
    public void EndDialogue()
    {
        Debug.Log("End of story");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Oscar")) 
        {
            save.SavePlayer();
            SceneManager.LoadScene("Markus");
        }
        else
        {
            save.LoadGame();
            SceneManager.LoadScene("ee");
        }
        
    }
}

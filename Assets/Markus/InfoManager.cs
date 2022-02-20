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


    // Queue anv�nder fifo (F�rst in, f�rst ut)
    private Queue<string> Sentences;

    // l�gger dit alla meningar man har skrivit
    void Start()
    {
        Sentences = new Queue<string>();
    }

    // en funkion som g�r att texten b�rjar 
    public void StartStory(InfoDump dialogue)
    {
        // clearar meningen efter den har blivit anv�nd
        Sentences.Clear();

        foreach (string Sentence in dialogue.Sentences)
        {
            Sentences.Enqueue(Sentence);
        }


        DisplayNextSentence();
    }


    // Visar n�sta mening
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

    // g�r att en bokstav skrivs itaget ist�llet f�r att skriva allt direkt
    IEnumerator TypeSentence(string Sentence)
    {
        StoryText.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            StoryText.text += letter;

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    // kollar ifall man �r i menyn eller huben n�r dialogen �r klar och laddar olika scener beroende p� vilken man �r i
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

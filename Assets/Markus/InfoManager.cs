using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoManager : MonoBehaviour
{
    public SaveData save;

    // är saker för ljud

    //public AudioSource AudioSource;
    public Text StoryText;


    // Queue använder fifo (Först in, först ut)
    private Queue<string> Sentences;

    // lägger dit alla meningar man har skrivit
    void Start()
    {
        //AudioSource = GetComponent<AudioSource>();
        Sentences = new Queue<string>();
    }

    // en funkion som gör att texten brjar 
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
        // audio play och stop gör att det bara spelar ljudet när den skriver

        //AudioSource.Play();
        StoryText.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            StoryText.text += letter;

            yield return new WaitForSecondsRealtime(0.05f);
        }
        //AudioSource.Stop();
    }

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

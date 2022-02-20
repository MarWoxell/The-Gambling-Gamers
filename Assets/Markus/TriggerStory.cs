using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrivet av Markus

    /// <summary>
    /// G�r att story startar som false och n�r man trycker p� knappen (StoryTrigger) b�rjar dialogen h�nda
    /// </summary>
public class TriggerStory : MonoBehaviour
{
    public InfoDump dialogue;

    public GameObject story;


    public void Start()
    {
        story.SetActive(false);
    }


    public void StoryTrigger()
    {
        story.SetActive(true);
        Invoke("StartStory", 1);
    }

    public void StartStory()
    {
        FindObjectOfType<InfoManager>().StartStory(dialogue);
    }
}

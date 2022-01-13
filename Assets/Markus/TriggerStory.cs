using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Warp : MonoBehaviour, Interactable
{
    public Object Destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Thing()
    {
        SceneManager.LoadScene(Destination.name);
    }
}

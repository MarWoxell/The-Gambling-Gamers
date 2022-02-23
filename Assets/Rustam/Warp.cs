using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Rustam
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
        //En interface som tar dig till scen X
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Rustam
public class MusicManager : MonoBehaviour
{


    public AudioSource PlayerSource;

    // Start is called before the first frame update
    void Start()
    {
        //Spelar bara rätt musik på loop
        PlayerSource.Play();
        PlayerSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

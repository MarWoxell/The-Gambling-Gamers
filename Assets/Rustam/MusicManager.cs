using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{


    public AudioSource PlayerSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

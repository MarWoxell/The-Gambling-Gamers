using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour, Interactable
{
    public GameObject[] Winnable;

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
        Gamble();
    }

    void Gamble()
    {
        int Result = Random.Range(1, Winnable.Length);
        print(Result);
    }
}

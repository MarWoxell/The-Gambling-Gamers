using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skrivet av Markus

public class SaveObject : MonoBehaviour
{
    public static SaveObject instance;


    public int money;
    public int pistolLv;
    public int arLv;
    public int shotgunLv;
    public float time;

    // skapar en ifall den inte finns och ifall den redan finns förstör den sig själv
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}

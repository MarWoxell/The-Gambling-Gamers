using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour
{
    public static SaveObject instance;


    public int money;
    public int pistolLv;
    public int arLv;
    public int shotgunLv;
    public float time;

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

    /*public void Update()
    {
        time = time + Time.deltaTime;
    }*/
}

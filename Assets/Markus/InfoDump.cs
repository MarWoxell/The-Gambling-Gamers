using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
public class InfoDump
{
    // Genom det h�r scriptet skriver man in all text i inspektorn
    [TextArea(4, 10)]
    public string[] Sentences;
}

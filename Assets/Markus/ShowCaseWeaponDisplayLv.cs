using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Markus 

    /// <summary>
    /// Updaterar text i hubben så vapen levlar syns
    /// </summary>

public class ShowCaseWeaponDisplayLv : MonoBehaviour
{
    public Text shotgun;

    public Text pistol;

    public Text ar;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pistol.text = SaveObject.instance.pistolLv.ToString();
        shotgun.text = SaveObject.instance.shotgunLv.ToString();
        ar.text = SaveObject.instance.arLv.ToString();
    }
}

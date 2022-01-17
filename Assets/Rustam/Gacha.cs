using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour, Interactable
{
    public Object[] Winnable;
    public Pistol pistol;
    public AR ak;
    public Shotgun shotgun;

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
        int Result = Random.Range(1, Winnable.Length + 1);
        print(Result);
        if(Result == 1)
        {
            pistol.WeaponLVL++;
        }
        if (Result == 2)
        {
            ak.WeaponLVL++;
        }
        if (Result == 3)
        {
            shotgun.WeaponLVL++;
        }

    }
}

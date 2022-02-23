using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Detta skript var skrivet av Rustam
public class Spherecast : MonoBehaviour
{
    
    public Text EnterText;
    private string EnterString;
    [SerializeField]
    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnterText.text = EnterString;
        RaycastHit hit;
        //checkar inom en sfär av x för objekt med interfacen interactable, och ifall den gör det så får man se en promt och möjligheten att interacta med E
        if (Physics.CheckSphere(transform.position, 1.5f, mask))
        {
            foreach (Collider Col in Physics.OverlapSphere(transform.position, 1.5f, mask))
            {
                //Checkar för objekt inom en sfär runt spelaren
                Transform cols = Col.transform;
                if (cols.GetComponent<Interactable>() != null)
                {
                    //Om objektet haren interface så displayas ui elementet och namnet
                    EnterString = cols.name;
                    //Prompt.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        cols.GetComponent<Interactable>().Thing();
                        //Interactar med interfacen om man trycker på e
                    }
                }
            }

        }
        else
        {
            EnterString = "";
            //Prompt.enabled = false;
            //Om det inte finns några interactible objekt så displayas inte ui element
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(SpherePos.position, 2);
        Gizmos.DrawWireSphere(transform.position, 1.5f);
        //Ritar en cirkel kring spelar i editorn för debugging
    }
}

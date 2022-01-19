using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Detta skript var skrivet av Rustam
public class Spherecast : MonoBehaviour
{
    //public RawImage Prompt;
    public TextMeshProUGUI EnterText;
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

        if (Physics.CheckSphere(transform.position, 2, mask))
        {
            foreach (Collider Col in Physics.OverlapSphere(transform.position, 2, mask))
            {
                //Checkar f�r objekt inom en sf�r runt spelaren
                Transform cols = Col.transform;
                if (cols.GetComponent<Interactable>() != null)
                {
                    //Om objektet haren interface s� displayas ui elementet och namnet
                    EnterString = cols.name;
                    //Prompt.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        cols.GetComponent<Interactable>().Thing();
                        //Interactar med interfacen om man trycker p� e
                    }
                }
            }

        }
        else
        {
            EnterString = "";
            //Prompt.enabled = false;
            //Om det inte finns n�gra interactible objekt s� displayas inte ui element
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(SpherePos.position, 2);
        Gizmos.DrawWireSphere(transform.position, 2);
        //Ritar en cirkel kring spelar i editorn f�r debugging
    }
}

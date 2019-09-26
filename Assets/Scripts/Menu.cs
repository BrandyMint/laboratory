using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject gg;
    public GameObject gg1;
    public GameObject gg2;
    public GameObject gg3;
    public Text text;
    // Start is called before the first frame update
    
  public void Start1()
    {
       

        if ((gg.activeSelf == true)) //&& (gg1.activeSelf == true))
        {
            
            gg2.transform.position = gg1.transform.position;
            gg1.transform.position = gg.transform.position;
            gg.SetActive(false);
            gg2.SetActive(true);

        }
        if ((gg1.activeSelf == true) && (gg2.activeSelf == true))
        {
            gg3.transform.position = gg2.transform.position;
            gg2.transform.position = gg1.transform.position;
            gg1.SetActive(false);
            gg3.SetActive(true);

        }
        if ((gg3.activeSelf == true) && (gg2.activeSelf == true))
        {
            gg.transform.position = gg3.transform.position;
            gg3.transform.position = gg2.transform.position;
            gg2.SetActive(false);
            gg.SetActive(true);

        }
        if ((gg3.activeSelf == true) && (gg.activeSelf == true))
        {
            gg1.transform.position = gg.transform.position;
            gg.transform.position = gg3.transform.position;
            gg3.SetActive(false);
            gg1.SetActive(true);

        }
    }

    // Update is called once per frame
  
}

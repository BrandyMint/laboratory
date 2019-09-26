using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;


public class Recolocation1 : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM3", 38400);
    public bool B_Check;
    public GameObject[] lamp1 = new GameObject[21];
    public GameObject[] gg = new GameObject[5];


    /* public GameObject lamp2;
     public GameObject lamp3;
     public GameObject lamp4;
     public GameObject lamp5;
     public GameObject lamp6;
     public GameObject lamp7;
     public GameObject lamp8;
     public GameObject lamp9;
     public GameObject lamp10;
     public GameObject lamp11;
     public GameObject lamp12;
     public GameObject lamp13;
     public GameObject lamp14;
     public GameObject lamp15;
     public GameObject lamp16;
     public GameObject lamp17;
     public GameObject lamp18;
     public GameObject lamp19;
     public GameObject lamp20;*/
    public Text text1;
    public void Start1()
    {
        if (!B_Check)
        {
            B_Check = true;
            sp.Open();
            text1.text = "";

        }
        else
        {
            B_Check = false;
            sp.Close();
            text1.text = "";
        }
        //lamp1 = GameObject.Find("New Sprite (2)");


        InvokeRepeating("Resolocation", 0.1f, 0.1f);
        // Process.Start("C:\\Users/lord1/source/repos/ConsoleApp15/ConsoleApp15/bin/Debug/ConsoleApp15.exe");
        // Invoke("Resolocation", 0.1f);
    }

    private void Resolocation()
    {
        if (B_Check)
        {
            string s = sp.ReadLine();
            s = s.Substring(s.IndexOf('L') + 1, s.IndexOf('T') - s.IndexOf('L') - 1);
            int f = (Convert.ToInt32(s));

            text1.text = f.ToString();
            int n = f / 60;
            if (n >= 1)
            {
                if (n <= 21)
                {
                    for (int i = 1; i < n; i++)
                    {

                        lamp1[i].SetActive(true);
                    }
                    if (n < 21)
                        for (int i = n; i < 21; i++)
                        {

                            lamp1[i].SetActive(false);
                        }
                }

            }
        }
    }
    void Update()
    {
        for (int i = 1; i < 21; i ++)
        {
            if (lamp1[i].activeSelf == true)
            {
                int j = i / 5;
                for (int k = 0; k < j; k++)
                    gg[k].SetActive(true);
            }
            if (i < 21)
            {
                int a = i / 5;
                for (int e = a; e < 4; e++)
                    gg[e].SetActive(false);
            }
        }
    }
}


    



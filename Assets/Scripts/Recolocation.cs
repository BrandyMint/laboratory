﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class Recolocation:MonoBehaviour {
    public GameObject game;
    public bool B_Check;
    public GameObject gg;
    public SerialPort sp = new SerialPort("COM3", 38400);
    public Text text;
    public GameObject text1;
    public float kek;
    public void Start1()
    {
        if (!B_Check)
        {
            B_Check = true;
            sp.Open();
            gg.SetActive(true);
            game.SetActive(true);
            text1.SetActive(true);
        }
        else
        {
            B_Check = false;
            sp.Close();
            gg.SetActive(false);
            game.SetActive(false);
            text1.SetActive(false);
        }
       InvokeRepeating("Resolocation", 0.1f, 0.1f);
       // Process.Start("C:\\Users/lord1/source/repos/ConsoleApp15/ConsoleApp15/bin/Debug/ConsoleApp15.exe");
       // Invoke("Resolocation", 0.1f);
    }
    public void Stop()
    {
        B_Check = false;
        sp.Close();
    }
        private void Resolocation()
    {
        if (B_Check)
        {
            string s= sp.ReadLine();
            s = s.Substring(s.IndexOf('T') + 1, s.IndexOf('E') - s.IndexOf('T') - 1);
            float f = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 100);
            game.transform.position = Vector3.Lerp(game.transform.position,new Vector3(game.transform.position.x, (-2.68f + (f * 0.05f)), game.transform.position.z),0.1f);
            game.transform.localScale = new Vector3(game.transform.localScale.x, 4.6737f + (f  * 0.09096f), game.transform.localScale.z);
            text.text = f.ToString();

        }

        
   
    }
 


    }


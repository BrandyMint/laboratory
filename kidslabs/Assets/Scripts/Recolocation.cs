using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;

public class Recolocation:MonoBehaviour {
    public GameObject game;
    public bool B_Check;
    public SerialPort sp = new SerialPort("COM3", 38400);
    public void Start1()
    {
        B_Check = true;
        sp.Open();
      // InvokeRepeating("Resolocation", 0.1f, 0.2f);
       // Process.Start("C:\\Users/lord1/source/repos/ConsoleApp15/ConsoleApp15/bin/Debug/ConsoleApp15.exe");
       // Invoke("Resolocation", 0.1f);
    }

        private void Update()
    {
        if (B_Check)
        {
            string s= sp.ReadLine();
            s = s.Substring(s.IndexOf('T') + 1, s.IndexOf('E') - s.IndexOf('T') - 1);
            float f = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 100);
            game.transform.position = new Vector2(game.transform.position.x, (-2.68f + (f  * 0.05f)));
            game.transform.localScale = new Vector3(game.transform.localScale.x, 4.6737f + (f  * 0.09096f), game.transform.localScale.z);


        }

        
   
    }
 


    }


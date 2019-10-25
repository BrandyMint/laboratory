using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;
public class Elek : MonoBehaviour
{
    public AudioClip[] audioo = new AudioClip[20];
    public SerialPort sp = new SerialPort("COM3", 9600);
    public bool sound_1;
    public bool sound_2;
    public bool sound_3;
    public bool sound_4;
    public GameObject shkala;
    public Quaternion qq;
    public AudioSource source;
    public GameObject girl;
    public GameObject[] backs = new GameObject[4];
    public Text text;
    public bool start;
    float f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((sound_1) && (!source.isPlaying))
        {
            source.clip = audioo[0];
            source.Play();
            sound_1 = false;
            girl.GetComponent<Animator>().Play("speak");
        }
        if ((sound_2) && (!source.isPlaying))
        {
            source.clip = audioo[1];
            source.Play();
            sound_2 = false;
            girl.GetComponent<Animator>().Play("speak 3");
            backs[0].SetActive(false);
            backs[1].SetActive(true);
        }
        if ((sound_3) && (!source.isPlaying))
        {
            source.clip = audioo[2];
            source.Play();
            sound_3 = false;
            girl.GetComponent<Animator>().Play("speak 4");

        }
        if ((sound_4) && (!source.isPlaying))
        {
            source.clip = audioo[3];
            source.Play();
            sound_4 = false;
            girl.GetComponent<Animator>().Play("speak 5");
            backs[0].SetActive(true);
            backs[1].SetActive(false);
            backs[2].SetActive(true);
            backs[3].SetActive(true);
        }
        if (start)
        {
            girl.GetComponent<Animator>().Play("idle 1");
            sp.Open();
            sp.ReadTimeout = 1;
            InvokeRepeating("Resolocation", 0.1f, 0.132f);
            Invoke("stopi", 15f);
            start = false;
        }

    }
    private void stopi()
    {

        sp.Close();
        CancelInvoke("Resolocation");
        source.clip = audioo[4];
        source.Play();
        girl.GetComponent<Animator>().Play("speak 6");
        

    }
    private void Resolocation()
    {

        {
            string s = sp.ReadLine();
            s = s.Substring(s.IndexOf('T') + 1, s.IndexOf('E') - s.IndexOf('T') - 1);
            f = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 100);
            shkala.transform.rotation= Quaternion.Euler(0, 0, -f); 
        
            text.text = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 500).ToString();
        }
    }
        }

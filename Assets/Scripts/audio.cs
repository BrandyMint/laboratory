using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class audio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioo = new AudioClip[20];
    public bool sound_1;
    public bool hotfree;
    public GameObject Fish;
    public GameObject girl;
    public bool sound_2;
    public bool sound_3;
    public bool sound_5;
    public SerialPort sp = new SerialPort("COM3", 1200);
    public Text text;
    public bool start;
    public GameObject shkala;
    public bool sound_4;
    public int a=0;
    public int b = 0;
    // Start is called before the first frame update
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
        }
        if (hotfree)
        {

            girl.GetComponent<Animator>().Play("idle");
            Fish.GetComponent<Animator>().Play("freezing");
            Invoke("frost", 1f);
            hotfree = false;
        }
        if ((sound_2) && (!source.isPlaying))
        {
            source.clip = audioo[1];
            source.Play();
            sound_2 = false;
        }
        if ((sound_3) && (!source.isPlaying))
        {
            source.clip = audioo[2];
            source.Play();
            sound_3 = false;
        }
     /*   if ((sound_4) && (!source.isPlaying))
        {
            source.clip = audioo[3];
            source.Play();
            sound_4 = false;
        }*/
        
        if (start)
        {
            if (!sp.IsOpen)
            {
                b++;
                sp.Open();
                start = false;
                InvokeRepeating("Resolocation", 0.1f, 0.132f);
            }
        }
    }
    void frost()
    {
        Fish.GetComponent<Animator>().Play("frost");
        Invoke("hot", 3f);
    }
    void hot()
    {
        Fish.GetComponent<Animator>().Play("hot");
        Invoke("idle", 3f);
    }
    void idle()
    {
        Fish.GetComponent<Animator>().Play("idle");
    }
    private void Resolocation()
    {

        {
            string s = sp.ReadLine();
            s = s.Substring(s.IndexOf('T') + 1, s.IndexOf('E') - s.IndexOf('T') - 1);
            float f = (float.Parse(s.Substring(0, s.IndexOf('.'))) / 100);
            shkala.transform.position = Vector3.Lerp(shkala.transform.position, new Vector3(shkala.transform.position.x, (-2.68f + (f * 0.05f)), shkala.transform.position.z), 0.1f);
            shkala.transform.localScale = new Vector3(shkala.transform.localScale.x, 4.6737f + (f * 0.09096f), shkala.transform.localScale.z);
            text.text = f.ToString();
            if ((f <15.5) && (f > 14.5) && (b==1))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("speak 5");
                if (!source.isPlaying)
                {
                    source.clip = audioo[3];
                    source.Play();
                    sound_3 = false;
                }
            }
            if ((f < 20.5) && (f > 19.5) && (b == 2))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("spech5");
                if (!source.isPlaying)
                {
                    source.clip = audioo[4];
                    source.Play();
                    sound_4 = false;
                }
            }
            if ((f < 30.5) && (f > 29.5) && (b == 3))
            {
                CancelInvoke("Resolocation");
                sp.Close();
                girl.GetComponent<Animator>().Play("spech6");
                if (!source.isPlaying)
                {
                    source.clip = audioo[5];
                    source.Play();
                    sound_5 = false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Management;
//using System.Management;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;

//[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
public class ComPortsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SerialPort.GetPortNames();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private string AutodetectArduinoPort()
    //{
    //    ManagementScope connectionScope = new ManagementScope();
    //    SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
    //    ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

    //    try
    //    {
    //        foreach (ManagementObject item in searcher.Get())
    //        {
    //            string desc = item["Description"].ToString();
    //            string deviceId = item["DeviceID"].ToString();

    //            if (desc.Contains("Arduino"))
    //            {
    //                return deviceId;
    //            }
    //        }
    //    }
    //    catch (ManagementException e)
    //    {
    //        /* Do Nothing */
    //    }

    //    return null;
    //}
    public string GetArduinoPort()
    {
        var ports = SerialPort.GetPortNames();

        var result = "";

        foreach (var item in ports)
        {
            try
            {
                var sp = new SerialPort();
                sp.
                sp.Open();
                sp.ReadTimeout = 1;
            }
            catch (System.Exception)
            {

                continue;
            }
        }

        return result;
    }
}

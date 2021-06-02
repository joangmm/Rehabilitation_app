using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System;

public class TrackingReceiver : MonoBehaviour
{
    private float startTimeBtwPrint = 1.0f;
    private float timeBtwPrint;


    //GameObjects to be controlled with Posenet
    public GameObject wristR;
    public GameObject wristL;

    //OSC Variables
    private OSCReceiver _receiver;
    private const string _oscAddress = "/pose/0";

    //Dictionary to store pose data
    public Dictionary<string, Vector3> pose = new Dictionary<string, Vector3>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        timeBtwPrint = startTimeBtwPrint;
        //Set up OSC receiver
        StartOSCReceiver();

        //Initialize pose
        StartPose();
    }

    void StartOSCReceiver()
    {
        // Creating a receiver.
        _receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        _receiver.LocalPort = 9876;

        // Bind "MessageReceived" method to special address.
        _receiver.Bind(_oscAddress, MessageReceived);
    }

    void StartPose()
    {
        pose.Add("rightWrist", Vector3.zero);
        pose.Add("leftWrist", Vector2.zero);


        //Escribe.WriteLine("FUNCIONAAAA :)");
        //Escribe.Close();
    }


    // Update is called once per frame
    void Update()
    {
        wristR.transform.position = pose["rightWrist"];
        wristL.transform.position = pose["leftWrist"];

        if (timeBtwPrint <= 0)
        {
            //UnityEngine.Debug.Log(wristR.transform.position);

            TextWriter Escribe = new StreamWriter("tracking_test.txt", true); //archivo donde se escribirán las posiciones de las manos

            Escribe.WriteLine(wristR.transform.position);
            Escribe.WriteLine(wristL.transform.position);

            Escribe.Flush();
            Escribe.Close();

            timeBtwPrint = startTimeBtwPrint;
        }
        else
        {
            timeBtwPrint -= Time.deltaTime;
        }


    }

    protected void MessageReceived(OSCMessage message)
    {
        List<OSCValue> list = message.Values;
        //UnityEngine.Debug.Log(list.Count);

        for (int i = 0; i < list.Count; i += 3)
        {
            string key = "";
            Vector2 position = Vector3.zero;

            OSCValue val0 = list.ElementAt(i);
            if (val0.Type == OSCValueType.String) key = val0.StringValue;
            OSCValue val1 = list.ElementAt(i + 1);
            if (val1.Type == OSCValueType.Float) position.x = val1.FloatValue - 250;
            OSCValue val2 = list.ElementAt(i + 2);
            if (val2.Type == OSCValueType.Float) position.y = -(val2.FloatValue - 250);

            if (pose.ContainsKey(key))
            {
                pose[key] = position;
            }
        }

    }
}

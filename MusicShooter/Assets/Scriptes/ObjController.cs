using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ObjController : MonoBehaviour {

    public float objSpeed;

    public GameObject objYellow;
    public GameObject objBlue;
    public GameObject objGreen;
    public Transform back;

    public int resolution = 1024;
    GameObject yellow, blue, green;
    public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
    public float lowEnhance = 1f, midEnhance = 10f, highEnhance = 100f;

    private float low = 0f, mid = 0f, high = 0f;
    private float lowDate = 0f, midDate = 0f, highDate = 0;

    private AudioSource audio_;

    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        audio_.Play();
    }

    void Update()
    {
        var spectrum = audio_.GetSpectrumData(resolution, 0, FFTWindow.BlackmanHarris);

        var deltaFreq = AudioSettings.outputSampleRate / resolution;

        lowDate = low; midDate = mid; highDate = high;
        low = 0f;      mid = 0f;      high = 0f;

        for (var i = 0; i < resolution; ++i)
        {
            var freq = deltaFreq * i;
            if (freq <= lowFreqThreshold) low += spectrum[i];
            else if (freq <= midFreqThreshold) mid += spectrum[i];
            else if (freq <= highFreqThreshold) high += spectrum[i];
        }

        float x = Random.Range(-1.96f, 1.96f);
        float y = Random.Range(-1.06f, 1.06f);

        float lowDiff = Mathf.Abs(lowDate - low);
        float midDiff = Mathf.Abs(midDate - mid);
        float highDiff = Mathf.Abs(highDate - high);

        if (lowDiff >= 0.5)
        {
            yellow = (GameObject)Instantiate(objYellow, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
        }
        if (midDiff >= 4)
        {
            blue = (GameObject)Instantiate(objBlue, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
        }
        if (highDiff >= 3)
        {
            green = (GameObject)Instantiate(objGreen, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
        }

        /*
        if(low >= 3)
        {
            yellow = (GameObject)Instantiate(objYellow, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
            
        }
        if (mid >= 0.45)
        {
            blue = (GameObject)Instantiate(objBlue, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
        }
        if (high >= 0.025)
        {
            green = (GameObject)Instantiate(objGreen, new Vector3(x, y, back.position.z), Quaternion.identity) as GameObject;
        }*/

        //Debug.Log(highDiff);
        if (yellow == null && blue == null && green == null) return;
        //Debug.Log(low);
        //yellow = objYellow.transform;
        //blue = objBlue.transform;
        //green = objGreen.transform;

        low *= lowEnhance;
        mid *= midEnhance;
        high *= highEnhance;

        //yellow.transform.localScale = new Vector3(yellow.transform.localScale.x, low, yellow.transform.localScale.z);
        //blue.transform.localScale = new Vector3(blue.transform.localScale.x, mid, blue.transform.localScale.z);
        //green.transform.localScale = new Vector3(green.transform.localScale.x, high, green.transform.localScale.z);
    }
    public float Low()
    {
        return low;
    }
    public float Mid()
    {
        return mid;
    }
    public float High()
    {
        return high;
    }
}

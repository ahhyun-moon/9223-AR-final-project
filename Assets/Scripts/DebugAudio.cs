using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DebugAudio : MonoBehaviour
{
    float[] _audio;
    TextMeshProUGUI text;
    void Start()
    {
        _audio = AudioPeer._samples; 
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        text.text = _audio[0].ToString();
    }
}

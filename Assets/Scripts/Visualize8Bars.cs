using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualize8Bars : MonoBehaviour
{
    // public int _maxScale;
    public int _index;
    public bool _useBuffer;
    void Update()
    {
        if(_useBuffer){
            gameObject.transform.localScale = new Vector3(0.01f, 0.001f + (AudioPeer._bandBuffer[_index]* 0.01f), 0.01f);
        } else {
            gameObject.transform.localScale = new Vector3(0.01f, 0.001f + (AudioPeer._freqBand[_index]* 0.01f), 0.01f);
        }
    }
}

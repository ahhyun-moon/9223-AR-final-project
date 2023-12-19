using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float _maxScale;
    private Vector3 currPos;
    void Start()
    {
        currPos = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(currPos.x, currPos.y + (AudioPeer._samples[0] * _maxScale), currPos.z);
    }
}

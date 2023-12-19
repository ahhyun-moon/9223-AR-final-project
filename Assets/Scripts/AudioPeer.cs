using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    // AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public AudioSource _audioSource;
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("Running audio visualization");

		foreach (string device in Microphone.devices) {
						Debug.Log ("Name: " + device);
				}

		if (_audioSource == null)
			_audioSource = GetComponent<AudioSource>();
		
		if (_audioSource == null) 
			_audioSource = gameObject.AddComponent<AudioSource>();
		
		_audioSource.clip = Microphone.Start(null, true, 1, 44100);
		while (!(Microphone.GetPosition(null) > 0)) { } // this line removes lag.
		_audioSource.loop = true;
		_audioSource.Play();
    }
    void OnDisable(){
        Microphone.End(null);
        _audioSource.clip = null;
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource(){
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer(){
        for (int i = 0; i < 8; ++i){
            if (_freqBand[i] > _bandBuffer[i]){
                _bandBuffer[i] = _freqBand[i];
                _bufferDecrease[i] = 0.005f;
            }
            if (_freqBand[i] < _bandBuffer[i]){
                _bandBuffer[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f;
            }
        }
    }
    void MakeFrequencyBands(){
        // 22050 / 512 = 43hertz per sample
        // Will divide into 8 bands
        // 0: 2 samples = 86 hertz
        // 1: 4 samples = 172 hertz => 87 - 258 
        // 2: 8 samples = 344 hertz => 259 - 602 
        // 3: 16 samples = 688 hertz => 603 - 1290 
        // 4: 32 samples = 1376 hertz => 1291 - 2666 
        // 5: 64 samples = 2752 hertz => 2667 - 5418 
        // 6: 128 samples = 5504 hertz => 5419 - 10922 
        // 7: 256 samples = 11008 hertz => 10923 - 21930 

        int count = 0;
        for(int i = 0; i < 8; i++){
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i + 1);
            if (i == 7){
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j++){
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }
}

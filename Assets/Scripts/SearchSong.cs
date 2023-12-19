using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;

public class SearchSong : MonoBehaviour, IPointerClickHandler {
    AudioClip recording;
    string filename = "search_recording.wav";
    public AudioSource audioSource;
    public TextMeshProUGUI textBox;
    public RawImage rawImage;
    public TextMeshProUGUI title;
    public TextMeshProUGUI artist;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData){
        StartCoroutine(Record());
        textBox.text = "Searching..";

    }

    IEnumerator Record(){
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("Microphone found");
            foreach (var device in Microphone.devices)
            {
                Debug.Log("Name: " + device);
            }            
        }
        // recording = Microphone.Start("iPhone audio input", false, 10, 44100);
        recording = Microphone.Start(null, false, 5, 44100);
        yield return new WaitForSecondsRealtime(5);
        if (Microphone.IsRecording(null)){
            Microphone.End(null);
        }
        SavWav.Save(filename, recording);
        Debug.Log(Path.Combine(Application.persistentDataPath, filename));
        audioSource.clip = recording;
        // audioSource.Play();
        StartCoroutine(Search());
    }
    IEnumerator Search(){
        // Load the audio file as a byte array
        byte[] audioData = File.ReadAllBytes(Path.Combine(Application.persistentDataPath, filename));

        // Create a WWWForm
        WWWForm form = new WWWForm();

        // Add fields to the form
        form.AddField("api_token", "55350c4836d0e62379d85b2ca5c4d116");
        form.AddField("return", "apple_music,spotify");

        // Add the audio file to the form
        form.AddBinaryData("file", audioData, filename, "audio/wav");

        UnityWebRequest www = UnityWebRequest.Post("https://api.audd.io/", form);
        // www.SetRequestHeader("Content-Type", "multipart/form-data");

        // Send the request
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success){
            Debug.LogError("Error uploading audio: " + www.error);
        }
        else{
            // Debug.Log("Server response: " + www.downloadHandler.text);
            textBox.gameObject.SetActive(false);
            audioSource.clip = null;
            ShowResult(www.downloadHandler.text);
        }
    }
    private void ShowResult(string response){
        var res = JsonConvert.DeserializeObject<SearchResponse>(response);
        string textURL = res.result.apple_music.artwork.url.Replace("{w}","200").Replace("{h}","200");
        StartCoroutine(GetText(textURL));
        textBox.text = "Tap to see\nwhat's playing";
        title.text = res.result.title;
        artist.text = res.result.artist;
        // Debug.Log(textURL);
    }
    IEnumerator GetText(string textureURL){
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(textureURL)){
            yield return uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }
            else{
                // Get downloaded asset bundle
                rawImage.texture = DownloadHandlerTexture.GetContent(uwr);
                title.gameObject.SetActive(true);
                artist.gameObject.SetActive(true);
                rawImage.gameObject.SetActive(true);
            }
        }
    }
}
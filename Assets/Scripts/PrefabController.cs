using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrefabController : MonoBehaviour, IPointerClickHandler {
    GameObject canvas;
    public int startObjectID;

    public void OnPointerClick(PointerEventData eventData){
        canvas = GameObject.FindGameObjectWithTag("canvasUI");
        Debug.Log("Child1: " + canvas.transform.GetChild(1).gameObject.name);
        Debug.Log("Child2: " + canvas.transform.GetChild(2).gameObject.name);
        if (startObjectID == 0){ // Change to cubes
            GameObject searchBox = GameObject.FindGameObjectWithTag("searchBox");
            searchBox.transform.GetChild(0).gameObject.SetActive(true);
            searchBox.transform.GetChild(1).gameObject.SetActive(false);
            searchBox.transform.GetChild(2).gameObject.SetActive(false);
            searchBox.transform.GetChild(3).gameObject.SetActive(false);

            Debug.Log("Changed to cubes");
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(true);
            // canvas.transform.GetChild(1).gameObject.GetComponent<AudioPeer>().
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("cubes");
            for (int i = 0; i < cubes.Length; i ++){
                cubes[i].SetActive(true);
            } 
            startObjectID = 1;  
        } else if (startObjectID == 1){ // Change to santa
            Debug.Log("Changed to santa");
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("cubes");
            for (int i = 0; i < cubes.Length; i ++){
                cubes[i].SetActive(false);
            } 
            canvas.transform.GetChild(2).gameObject.SetActive(true);
            startObjectID = 2;
        }   else if (startObjectID == 2){ // Change to searchBox
            Debug.Log("Changed to searchBox");
            canvas.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            startObjectID = 0;
        }

    }
}

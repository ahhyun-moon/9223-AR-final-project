using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    public float radius;
    // private Vector3 currScale;

    void OnEnable()
    {
        Debug.Log(gameObject.transform.position);
        // currScale = gameObject.transform.localScale;
        for (int i = 0; i < 512; i++){
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = SetCirclePos(i);
            _instanceSampleCube.gameObject.tag = "cubes";
            _instanceSampleCube.transform.localScale = new Vector3(0.001f, 0.0001f, 0.001f);
            _instanceSampleCube.name = "SampleCube" + i;
            _sampleCube[i] = _instanceSampleCube;
        }
    }
    void Update(){
        for (int i = 0; i < 512; i++){
            if (_sampleCube != null){
                _sampleCube[i].transform.localScale = new Vector3(0.001f, 0.0001f + (AudioPeer._samples[i]* _maxScale), 0.001f);
                _sampleCube[i].transform.position = SetCirclePos(i);
            }
        }
    }
    Vector3 SetCirclePos(int i){
        // Debug.Log("Count: " + i);
        float circleposition = (float)i / (float)512;
        float x = Mathf.Sin( circleposition * Mathf.PI * 2.0f ) * radius;
        float z = Mathf.Cos( circleposition * Mathf.PI * 2.0f ) * radius;
        Vector3 newPos = new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y, transform.position.z + z);
        return newPos;
    }
}

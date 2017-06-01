using System.Collections;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public float RotateSpeed = 1.0f;

    Vector3 spinSpeed = new Vector3(0, 0, 0);
    Vector3 spinAxis = Vector3.up; 

	// Use this for initialization
	void Start () {
        spinSpeed = new Vector3(Random.value, Random.value, Random.value);
        spinAxis.x = .1f * (Random.value - Random.value);
	}
	
    public void SetSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(spinSpeed);
        this.transform.RotateAround(Vector3.zero, spinAxis, RotateSpeed);
	}
}

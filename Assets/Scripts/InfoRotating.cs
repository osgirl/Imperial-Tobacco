using UnityEngine;
using System.Collections;

public class InfoRotating : MonoBehaviour {

    GameObject cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("ARCamera");

    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up);
//        new Quaternion(0, cam.transform.rotation.y, 0, 0);
	}
}

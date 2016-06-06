using UnityEngine;
using System.Collections;

public class SceneAnimations : MonoBehaviour {

    public GameObject podium;
    public GameObject sigarette;
	// Use this for initialization
	void Start () {
	
	}

    void OnEnable() {
        StartCoroutine(Open());
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnDisable() {
        sigarette.transform.localPosition = new Vector3(sigarette.transform.localPosition.x, -1.6f, sigarette.transform.localPosition.z);
    }

    IEnumerator Open() {
        yield return new WaitForSeconds(1);
        podium.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(2.5f);

        while (sigarette.transform.localPosition.y < 4) {
            sigarette.transform.Translate(Vector3.up*0.03f);
            yield return new WaitForSeconds(0.01f);
        }
        podium.GetComponent<Animator>().SetTrigger("Close");
    }
}

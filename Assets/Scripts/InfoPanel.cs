using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour {

    RectTransform panelTransform;
	// Use this for initialization
	void Start () {
        panelTransform = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open() {
        GetComponent<Animator>().SetTrigger("Open");
//        StartCoroutine(OpenAnim());
    }

    public void Close() {
        GetComponent<Animator>().SetTrigger("Close");
//        StartCoroutine(CloseAnim());
    }

    IEnumerator OpenAnim() {
        while (panelTransform.localScale.x < 1) {
            panelTransform.localScale = new Vector3(panelTransform.localScale.x+0.1f, panelTransform.localScale.y + 0.1f, 1);
            yield return new WaitForSeconds(0.01f);
        }
        panelTransform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator CloseAnim() {
        while (panelTransform.localScale.x > 0)
        {
            panelTransform.localScale = new Vector3(panelTransform.localScale.x - 0.1f, panelTransform.localScale.y - 0.1f, 1);
            yield return new WaitForSeconds(0.01f);
        }
        panelTransform.localScale = new Vector3(0, 0, 1);
    }
}

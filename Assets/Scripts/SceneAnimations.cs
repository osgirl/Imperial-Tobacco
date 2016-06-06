using UnityEngine;
using System.Collections;

public class SceneAnimations : MonoBehaviour {

    public GameObject podium;
    public GameObject sigarette;
    bool isOpen = false;
    bool isMoving;
    public GameObject info;
    bool isSigaretteOnScreen;
    // Use this for initialization
    void Start () {
	
	}

    void OnEnable() {
//        StartCoroutine(Open());
    }

	// Update is called once per frame
	void Update () {
        UserInput();
    }

    //void OnDisable() {
    //    sigarette.GetComponent<Animator>().SetTrigger("Start");
    //    sigarette.transform.localPosition = new Vector3(sigarette.transform.localPosition.x, -1.6f, sigarette.transform.localPosition.z);
    //    sigarette.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
    //}

    public void UserInput()
    {
        if (!Application.isEditor)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Sigarette")
                    {
                        if (isOpen) StartCoroutine(CloseSigarette(hit.transform.gameObject));
                        else StartCoroutine(Open(hit.transform.gameObject));
                    }
                    if (hit.transform.gameObject.tag == "Podium" && !isOpen &&!isMoving) {
                        if (isSigaretteOnScreen) StartCoroutine(Close());
                        else StartCoroutine(Open());
                    }
                }

            }
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Sigarette")
                    {
                        if (isOpen) StartCoroutine(CloseSigarette(hit.transform.gameObject));
                        else StartCoroutine(Open(hit.transform.gameObject));
                    }
                    if (hit.transform.gameObject.tag == "Podium"&& !isOpen && !isMoving)
                    {
                        if (isSigaretteOnScreen) StartCoroutine(Close());
                        else StartCoroutine(Open());
                    }
                }

            }
        }

    }

    IEnumerator Open(GameObject go)
    {
        isMoving = true;
        go.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(1.5f);
        info.SetActive(true);
        isOpen = true;
        isMoving = false;
    }

    IEnumerator CloseSigarette(GameObject go)
    {
        isMoving = true;
        info.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        isOpen = false;
        go.GetComponent<Animator>().SetTrigger("Close");
        yield return new WaitForSeconds(1.5f);
        isMoving = false;
    }

    IEnumerator Open() {
        isMoving = true;
        yield return new WaitForSeconds(1);
        podium.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(2.5f);

        Transform sig = sigarette.transform;
        while (sig.localPosition.y < 4) {
            sig.Translate(Vector3.up*0.5f);
            yield return new WaitForSeconds(0.05f);
        }
        podium.GetComponent<Animator>().SetTrigger("Close");

        while (sig.localScale.x < 3) {
            sig.localScale = new Vector3(sig.localScale.x+0.05f, sig.localScale.y + 0.05f, sig.localScale.z + 0.05f);
            sig.Translate(Vector3.up * 0.18f);
            yield return new WaitForSeconds(0.05f);
        }
        isMoving = false;
        isSigaretteOnScreen = true;
    }

    IEnumerator Close()
    {
        isMoving = true;
        Transform sig = sigarette.transform;
        while (sig.localScale.x > 1.7f)
        {
            sig.localScale = new Vector3(sig.localScale.x - 0.05f, sig.localScale.y - 0.05f, sig.localScale.z - 0.05f);
            sig.Translate(Vector3.down * 0.18f);
            yield return new WaitForSeconds(0.05f);
        }
        podium.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(2.5f);

        while (sig.localPosition.y > -1.64f)
        {
            sig.Translate(Vector3.down * 0.5f);
            yield return new WaitForSeconds(0.05f);
        }
        podium.GetComponent<Animator>().SetTrigger("Close");
        isMoving = false;
        isSigaretteOnScreen = false;
        //      yield return new WaitForSeconds(1);
    }
}

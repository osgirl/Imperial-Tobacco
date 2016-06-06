using UnityEngine;
using System.Collections;

public class Sigarette : MonoBehaviour {
    bool isOpen = false;
    public GameObject info;
//    public GameObject tobacco;
//    public GameObject filter;
//    public GameObject filter2;
//    public GameObject[] components;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        UserInput();
    }
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
                }

            }
        }

    }

    IEnumerator Open(GameObject go) {
        go.GetComponent<Animator>().SetTrigger("Open");
        //        yield return new WaitUntil(() => g.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Open"));
        yield return new WaitForSeconds(1.5f);
        info.SetActive(true);
        //while (components[2].transform.localPosition.x > -0.0648f) {
        //    components[2].transform.localPosition = new Vector3(components[2].transform.localPosition.x-0.001f,
        //                                              components[2].transform.localPosition.y+0.001f,
        //                                              components[2].transform.localPosition.z);
        //    components[0].transform.localPosition = new Vector3(components[0].transform.localPosition.x + 0.001f,
        //                                              components[0].transform.localPosition.y + 0.001f,
        //                                              components[0].transform.localPosition.z);
        //    components[1].transform.localPosition = new Vector3(components[0].transform.localPosition.x,
        //                                              components[0].transform.localPosition.y + 0.001f,
        //                                              components[0].transform.localPosition.z);

        //    foreach (GameObject g in components) {
        //        g.transform.localScale = new Vector3(g.transform.localScale.x + 0.0005f,
        //   g.transform.localScale.y + 0.0005f,
        //   g.transform.localScale.z + 0.0005f);

        //    }

        //    yield return new WaitForSeconds(0.05f);
        //}
        //components[2].transform.localPosition = new Vector3(-0.0648f, 0.0222f, components[2].transform.localPosition.z);
        //components[0].transform.localPosition = new Vector3(-0.0245f, 0.0222f, components[0].transform.localPosition.z);
        //components[1].transform.localPosition = new Vector3(-0.0245f, 0.0222f, components[1].transform.localPosition.z);

        //        gameObject.transform.localScale = new Vector3(380, 380, 380);
        isOpen = true;
        
    }

    IEnumerator CloseSigarette(GameObject go) {

        //       yield return new WaitUntil(() => g.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Close"));
        //        yield return new WaitForSeconds(1f);
        //while (components[2].transform.localPosition.x <-0.0448f)
        //{
        //    components[2].transform.localPosition = new Vector3(components[2].transform.localPosition.x + 0.001f,
        //                                              components[2].transform.localPosition.y - 0.001f,
        //                                              components[2].transform.localPosition.z);
        //    components[0].transform.localPosition = new Vector3(components[0].transform.localPosition.x - 0.001f,
        //                                              components[0].transform.localPosition.y - 0.001f,
        //                                              components[0].transform.localPosition.z);
        //    components[1].transform.localPosition = new Vector3(components[0].transform.localPosition.x,
        //                                              components[0].transform.localPosition.y - 0.001f,
        //                                              components[0].transform.localPosition.z);

        //    foreach (GameObject g in components)
        //    {
        //        g.transform.localScale = new Vector3(g.transform.localScale.x - 0.0005f,
        //   g.transform.localScale.y - 0.0005f,
        //   g.transform.localScale.z - 0.0005f);

        //    }
        info.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        //}
        //components[2].transform.localPosition = new Vector3(-0.0448f,
        //                                              0.0002f,
        //                                              components[2].transform.localPosition.z);
        //components[0].transform.localPosition = new Vector3(-0.0445f,
        //                                          0.0002f,
        //                                          components[0].transform.localPosition.z);
        //components[1].transform.localPosition = new Vector3(components[1].transform.localPosition.x,
        //                                           0.0002f,
        //                                           components[1].transform.localPosition.z);

        isOpen = false;
        go.GetComponent<Animator>().SetTrigger("Close");
    }
}

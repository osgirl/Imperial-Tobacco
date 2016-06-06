using UnityEngine;
using System.Collections;

public class Sigarette : MonoBehaviour {


//    public GameObject tobacco;
//    public GameObject filter;
//    public GameObject filter2;
//    public GameObject[] components;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
//        UserInput();
    }

    void OnDisable()
    {
 //       GetComponent<Animator>().SetTrigger("Start");
    }

    //public void UserInput()
    //{
    //    if (!Application.isEditor)
    //    {
    //        if (Input.GetTouch(0).phase == TouchPhase.Began)
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //            RaycastHit hit;

    //            if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
    //            {
    //                if (hit.transform.gameObject.tag == "Sigarette")
    //                {
    //                    if (isOpen) StartCoroutine(CloseSigarette(hit.transform.gameObject));
    //                    else StartCoroutine(Open(hit.transform.gameObject));
    //                }
    //            }

    //        }
    //    }

    //    if (Application.isEditor)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit hit;

    //            if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
    //            {
    //                if (hit.transform.gameObject.tag == "Sigarette")
    //                {
    //                    if (isOpen) StartCoroutine(CloseSigarette(hit.transform.gameObject));
    //                    else StartCoroutine(Open(hit.transform.gameObject));
    //                }
    //            }

    //        }
    //    }

//    }

   
}

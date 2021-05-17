using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject welcomeText;


    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        welcomeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cam1.transform.position.x == 1.8f)
        {
            welcomeText.SetActive(true);
        }

        if (cam1.transform.position == new Vector3(1.8f, 3.1f, 0.3f))
        {
            cam1.SetActive(false);
            welcomeText.SetActive(false);
            cam2.SetActive(true);
        }
    }
}

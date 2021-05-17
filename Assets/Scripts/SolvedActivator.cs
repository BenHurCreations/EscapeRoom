using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedActivator : MonoBehaviour
{
    // Keys variables
    public GameObject firstKey;
    public GameObject secondKey;
    public GameObject thirdKey;
    Color green = new Color(0, 1, 0, 1);
    
    // Door Variables
    public GameObject openWall;

    // Camera management
    public GameObject winCam;
    public GameObject mainCam;
    public GameObject winText;

    public void SetColors()
    {
        StartCoroutine(ChangeColor(1.5f));
    }


    IEnumerator ChangeColor(float timeDelay)
    {
        // Change cameras
        yield return new WaitForSeconds(1);
        mainCam.SetActive(false);
        winCam.SetActive(true);
        yield return new WaitForSeconds(1);
        
        // Decide which key to activate
        Color color1 = firstKey.GetComponent<MeshRenderer>().material.color;
        Color color2 = secondKey.GetComponent<MeshRenderer>().material.color;
        if (color1.Equals(green) && color2.Equals(green))
        {
            thirdKey.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", green);
            yield return new WaitForSeconds(1);
            // Activate finish animation
            winCam.transform.Rotate(0, -180, 0);
            yield return new WaitForSeconds(0.5f);
            openWall.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(3);
            winText.SetActive(true);
            yield return new WaitForSeconds(2);
            openWall.SetActive(false);
        }
        else if (color1.Equals(green))
        {
            secondKey.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", green);
        }
        else
        {
            firstKey.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", green);
        }
        yield return new WaitForSeconds(timeDelay);
        winCam.SetActive(false);
        mainCam.SetActive(true);
    }
}

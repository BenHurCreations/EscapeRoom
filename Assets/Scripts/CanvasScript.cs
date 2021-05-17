using UnityEngine;


public class CanvasScript : MonoBehaviour
{
    public GameObject Canvas;
    bool firstOpen = true;
    public SolvedActivator _solved;


    void Start()
    {
        Canvas.SetActive(false);
    }


    void Update()
    {
        float pressed = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        if (pressed > 0.8)
        {
            Canvas.SetActive(true);
            if(firstOpen)
            {
                _solved.SetColors();
                firstOpen = false;
            }
        }
        else
        {
            Canvas.SetActive(false);
        }
    }
}
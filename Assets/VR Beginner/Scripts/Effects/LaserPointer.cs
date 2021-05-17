using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    // Effects variable
    public GameObject fire;
    
    // Laser Variables
    LineRenderer m_LineRenderer;
    
    // Animation activator variable
    public AnimationChess animationActivator;

    // Win indicator
    bool didWin = false;


    void Start()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 1000.0f, ~0, QueryTriggerInteraction.Ignore))
        {
            if(hit.collider.tag != "laser")
            {
                m_LineRenderer.SetPosition(1, new Vector3(0.0f, hit.distance, 0.0f));
            }
            if (hit.collider.name == "PrisonRoof" || hit.collider.name == "PrisonWall4")
            {
                Debug.Log("hit");
            }
            if (hit.collider.name == "RookLight (1)")
            {
                fire.GetComponent<ParticleSystem>().Play();
            }
            
            // Activate chess animas
            if(fire.activeSelf == true && hit.collider.name == "ChessActivator" && !didWin)
            {
                fire.SetActive(false);
                animationActivator.ActivateAnima();
                didWin = true;
            }
        }
        else
        {
            m_LineRenderer.SetPosition(1, new Vector3(0, 100.0f, 0));
        }
    }
}

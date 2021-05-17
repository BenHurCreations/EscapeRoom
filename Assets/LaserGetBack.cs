using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGetBack : MonoBehaviour
{
    // Laser Variables
    public GameObject laser;
    float x, y, z;
    float xR, yR, zR;

    // Start is called before the first frame update
    void Start()
    {
        x = laser.transform.position.x;
        y = laser.transform.position.y;
        z = laser.transform.position.z;
        xR = laser.transform.rotation.x;
        yR = laser.transform.rotation.x;
        zR = laser.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        bool laserBack = OVRInput.Get(OVRInput.Button.Four);
        if (laserBack)
        {
            Debug.Log("Yes");
            laser.transform.position = new Vector3(x, y, z);
            laser.transform.rotation = Quaternion.Euler(xR, yR, zR);
        }
    }
}

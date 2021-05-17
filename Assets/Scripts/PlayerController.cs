using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movement variables
    private Rigidbody rb;
    public float speed = 0;
    public GameObject _player;
    private Vector3 ballMovement;

    // Jump variables
    private Vector3 jump;
    public float jumpForce = 2.0f;

    // Game variables
    private float pointsCounter = 0;
    float x, y, z;
    GameObject[] points;
    GameObject point;

    // Win variable
    public SolvedActivator solved;
    bool didIt = false;

    // Effect variable
    public GameObject winEffect;
    public GameObject fire1, fire2, fire3, fire4;


    // Start is called before the first frame update
    void Start()
    {
        x = _player.transform.position.x;
        y = _player.transform.position.y;
        z = _player.transform.position.z;
        points = GameObject.FindGameObjectsWithTag("Point");
        rb = _player.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        ballMovement = new Vector3(2.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        // If player won
        if (pointsCounter == 4)
        {
            pointsCounter = 0;
            didIt = true;
            solved.SetColors();
            winEffect.GetComponent<ParticleSystem>().Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ball Movement
        bool ballRightMovement = OVRInput.Get(OVRInput.Button.One);
        bool ballLeftMovement = OVRInput.Get(OVRInput.Button.Two);
        bool ballJump = OVRInput.Get(OVRInput.Button.Three);
        if (ballJump)
        {
            rb.AddForce(jump * jumpForce);
        }
        if (ballRightMovement)
        {
            rb.AddForce(ballMovement * speed);
        }
        if (ballLeftMovement)
        {
            rb.AddForce(-ballMovement * speed);
        }
    }

    // Get points for going on the right track
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Point")
        {
            collision.collider.gameObject.SetActive(false);
            pointsCounter++;
        }

        // Try again if didn't solve
        if (collision.collider.name == "Wall Rail (14)" && pointsCounter < 4 && !didIt)
        {
            float fireX = _player.transform.position.x;
            ActivateFire(fireX);
            _player.transform.position = new Vector3(x, y, z);
            pointsCounter = 0;
            foreach (GameObject point in points)
            {
                point.SetActive(true);
            }
        }
    }

    // Activate fire effects
    void ActivateFire(float xF)
    {
        Debug.Log(xF);
        if (xF > -2.4f && xF < 1.5f)
        {
            fire1.GetComponent<ParticleSystem>().Play();
        }
        else if (xF > -3.6f && xF < -2.8f)
        {
            fire2.GetComponent<ParticleSystem>().Play();
        }
        else if (xF > -4.7f && xF < -3.9f)
        {
            fire3.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            fire4.GetComponent<ParticleSystem>().Play();
        }
    }
}

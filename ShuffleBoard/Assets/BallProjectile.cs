using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallProjectile : MonoBehaviour {

    //public Transform spawn;

    public bool m_isRunning = false;
    Rigidbody m_rb = null;

    public Vector3 m_initialVelocity;
    float m_timeElasped;
    float x, y, z;


    float x_guage;
    public Image guageBar;
    bool goingRight;

    bool fire;

    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
        goingRight = true;
        fire = false;
        x = 1;
        y = 0;
        z = 0;
    }
	
	// Update is called once per frame
	void Update () {
        x = x_guage * 42;

        m_initialVelocity = new Vector3(x,y,z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire = true;
            m_isRunning = !m_isRunning;
            m_rb.velocity = m_initialVelocity;
            
        }

        m_rb.useGravity = m_isRunning;

        if (m_rb.velocity.magnitude > 0.0001f)
        {
            m_timeElasped += Time.deltaTime;
        }
	}

    private void LateUpdate()
    {
        //Guage
        if (!fire)
        {

            if (x_guage >= 1)
            {
                goingRight = false;
            }
            else if (x_guage <= 0)
            {
                goingRight = true;
            }
            //Guage
            if (goingRight)
            {
                x_guage += Time.deltaTime;
            }
            else if (!goingRight)
            {
                x_guage -= Time.deltaTime;
            }

            guageBar.rectTransform.localScale = new Vector3(x_guage, 1, 1);
        }

        //Guage
    }
    /*
    public void Launch (int num)
    {
        if (num == 1)
        {
            m_initialVelocity = new Vector3(8,5,0);
            m_isRunning = !m_isRunning;
            m_rb.velocity = m_initialVelocity;
        }
        else if (num == 2)
        {
            m_initialVelocity = new Vector3(0, 0, 0);
            m_isRunning = !m_isRunning;
            m_rb.velocity = m_initialVelocity;
        }
        else if (num==3)
        {
            m_initialVelocity = new Vector3(0, 0, 0);
            m_isRunning = !m_isRunning;
            m_rb.velocity = m_initialVelocity;
        }
    }

    */
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Time:" + m_timeElasped);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cubes")
        {
            m_isRunning = !m_isRunning;
            Destroy(col.gameObject);
            //transform.position = spawn.transform.position;
            m_initialVelocity = new Vector3(0,0,0);

            Instantiate(gameObject,spawn.transform.position,spawn.transform.rotation);
            Destroy(gameObject);
        }
    }
    */
}

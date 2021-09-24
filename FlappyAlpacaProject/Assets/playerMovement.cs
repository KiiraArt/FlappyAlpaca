using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody rb; //Este es el rigidbody de nuestro objeto
    public float jumpForce; //Fuerza con la que saltamos
    public float runForce;  //Fuerza con la que avanzamos
    public GameObject cam; //Camara del player
    public GameObject psDead;
    public GameObject GFX;

    private Quaternion startRot;
    private void Start()
    {
        startRot = cam.transform.rotation;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)) {

            rb.velocity = Vector3.zero; //Para al player antes de aplicar la fuerza
            rb.AddForce(new Vector3(0, jumpForce, 0) * rb.mass); //Aplicamos la fuerza
        
        }

        Vector3 tmp = rb.velocity;
        tmp.x = runForce;
        rb.velocity = tmp;


    }


    //Esto se ejecuta cuando el collider detecta una colison
    private void OnCollisionEnter(Collision collision)
    {
        cam.transform.parent = null;
        cam.transform.rotation = startRot;

        psDead.transform.parent = null;
        psDead.GetComponent<ParticleSystem>().Play();

        Destroy(this.gameObject);


    }

}

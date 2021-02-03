using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class seed4 : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject goal;
    public Rigidbody rb;
    float speed = 1f;
    Vector3 direction;
    public GameObject root;
    public AudioSource correct;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == spawnPoint.position)
        {
            transform.position = spawnPoint.position;
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            direction = transform.position - goal.transform.position;
            rb.velocity = direction.normalized * -speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            transform.position = spawnPoint.position;
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.tag == "Seed4")
        {
            Debug.Log("Hit");
            correct.Play();
            Destroy(root);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

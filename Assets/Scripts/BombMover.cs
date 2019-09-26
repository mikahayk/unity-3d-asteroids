using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }


}

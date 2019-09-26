using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdController : MonoBehaviour
{
    GameController myController;
    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;


    [SerializeField]
    float _moveSpeed = 0.1f;

    [SerializeField]
    float _rotateSpeed = 1f;

    public float fireRate;
    private float nextFire;


    private void Start()
    {
        myController = FindObjectOfType<GameController>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if(myController.isGameOver != true)
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                return;

            var move = Vector3.zero;
            var rotate = 0f;

            //if (Input.GetKey(KeyCode.W))
            //    move += transform.forward;
            if (Input.GetKey(KeyCode.A))
                move += -transform.right;
            //if (Input.GetKey(KeyCode.S))
            //    move += -transform.forward;
            if (Input.GetKey(KeyCode.D))
                move += transform.right;

            if (Input.GetKey(KeyCode.E))
                rotate += 1;
            if (Input.GetKey(KeyCode.Q))
                rotate -= 1;

            var moveSpeed = move * _moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
                moveSpeed *= 2;

            transform.Rotate(Vector3.up, _rotateSpeed * rotate);

            transform.position += moveSpeed;


            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                audioSource.Play();
                GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }

        
      

    }
}

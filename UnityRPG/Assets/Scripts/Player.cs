using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //[Header("Body")]
    private Rigidbody rig;
    private Transform trans;

    [Header("Stats")]
    public int curHp;
    public int maxHp;

    [Header("Movement")]
    public float jumpForce;
    public float rotateSpeed;
    public float moveSpeed;

    //[Header("Camera")]
    private Camera cam;

    private bool qwerty = true;

    void Awake()
    {
        // Get components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();

        // jump
        if (Input.GetButtonDown("Jump"))
            TryJump();
    }

    void Rotate()
    {
        if (Input.GetKey("e"))
            trans.Rotate(0.0f, rotateSpeed, 0.0f, Space.Self);
        if (qwerty) {
            if (Input.GetKey("q"))
                trans.Rotate(0.0f, -rotateSpeed, 0.0f, Space.Self);
        }
    }

    void Move()
    {
        // get x and z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 dir = transform.right * x + transform.forward * z; // convert world axes to local axes
        dir.y = rig.velocity.y;

        // apply velocity
        rig.velocity = dir;
    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 1.1f))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

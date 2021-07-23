using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //[Header("Body")]
    private Rigidbody rig;

    [Header("Stats")]
    public int curHp;
    public int maxHp;

    [Header("Movement")]
    private float moveSpeed = 4.0f;

    //[Header("Camera")]
    private Camera cam;

    void Awake()
    {
        // Get components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
}

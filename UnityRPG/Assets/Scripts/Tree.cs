using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool isChopped = false;
    public GameObject log;
    public GameObject leaves;

    void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        ChopDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChopDown()    
    {
        //disable mesh renderers
        log.SetActive(false);
        leaves.SetActive(false);
        //enable isChopped
        isChopped = true;
    }
}

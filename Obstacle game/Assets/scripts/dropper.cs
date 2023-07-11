using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    [SerializeField] float timeToFloat = 5;
    // Start is called before the first frame update
    void Start()
    {
        renderer=GetComponent<MeshRenderer>();
        renderer.enabled=false;
        rigidbody=GetComponent<Rigidbody>();
        rigidbody.useGravity=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToFloat)
        {
            renderer.enabled=true;
            rigidbody.useGravity=true;
            // Debug.Log("5 secs has elapsed");
        }
        // Debug.Log(Time.time);
    }
}

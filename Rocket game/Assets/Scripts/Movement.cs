
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=1000f;
    [SerializeField] float rotaionThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      ProcessThrust(); 
      ProcessRotation(); 
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); //vector3.up= 0,1,0
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if(!mainEngineParticles.isPlaying)
            {
            mainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
      
    }
     void ProcessRotation()
     {
        if(Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation=true;
            transform.Rotate(Vector3.forward * rotaionThrust * Time.deltaTime); //0,0,1
            rb.freezeRotation=false;
            if(!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
            
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation=true;
            transform.Rotate(-Vector3.forward * rotaionThrust * Time.deltaTime);
            rb.freezeRotation=false;
            if(!rightThrusterParticles.isPlaying)
            {
            rightThrusterParticles.Play();
            }
        }
        else
        {
           rightThrusterParticles.Stop();
           leftThrusterParticles.Stop();
        }
        
       
     }
}

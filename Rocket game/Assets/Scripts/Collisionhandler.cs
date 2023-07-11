using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisionhandler : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    bool isTransitioning = false;
    // bool collisionDisable = false;
    AudioSource audioSource;
    void OnCollisionEnter(Collision other) 
    {
        if(!isTransitioning)
        {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                StartCrashSequence();
                break;
        } 
        } 
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel" , LevelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel" , LevelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);//0
    }
     
    void LoadNextLevel()
    {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex + 1;
       if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
       {
        nextSceneIndex = 0;
       }
    //    SceneManager.LoadScene(nextSceneIndex);
       SceneManager.LoadScene(currentSceneIndex + 1); // to move to next level
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      RespondToDebugKeys();  
    }
    void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        // else if(Input.GetKeyDown(KeyCode.C))
        // {
        //    collisionDisable = !collisionDisable;   //toggle collision 
        // }
    }
}

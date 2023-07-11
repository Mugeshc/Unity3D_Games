using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // to move the object without user input
    // [SerializeField] float x=0;
    [SerializeField] float y=0;
    [SerializeField] float moveSpeed=10;
    // [SerializeField] float z=0;

    // Start is called before the first frame update
    void Start()
    {
       PrintInstruction(); 
    }

    // Update is called once per frame
    void Update()
    {
        // float x=Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // float z=Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        // transform.Translate(x,y,z);
        MovePlayer();
    }

    void  PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("use the keys WASD or the arrow keys to move the player");
        Debug.Log("Dont hit the walls while moving thje player");
    }

    void MovePlayer()
    {
        float x=Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float z=Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(x,y,z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHit : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) 
   {
    //    Debug.Log("Hitted into the walls");
       if(other.gameObject.tag=="Player")
       {
       GetComponent<MeshRenderer>().material.color = Color.red;
       gameObject.tag="Hit";
       }
   }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorer : MonoBehaviour
{
  int hits = 0;

  private void OnCollisionEnter(Collision other)
  {
      if(other.gameObject.tag!="Hit")
      {
      hits++; //hits=hits+1
      Debug.Log("No. of times touched the wall : " + hits);
    //   Debug.Log(hits);
      }
  }
}

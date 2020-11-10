using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
  void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(0.5f, 0, 0));
            //GetComponent<Transform>().Translate(Vector3.left, right...); works
            //transform. can replace GetCompt...>() section
            //GetComponent<Animator>().Play("Right");
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Transform>().Translate(new Vector3(-0.5f,0,0));
                //GetComponent<Animator>().Play("Left");
            
            }
            else if (Input.GetKey(KeyCode.UpArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0,0.5f,0));
                }

              else if (Input.GetKey(KeyCode.DownArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0,-0.5f,0));
                }
                else
                {
                    //GetComponent<Animator>().Play("Idle");
                }
    }
}

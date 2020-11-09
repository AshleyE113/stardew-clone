using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
  void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().Translate(new Vector3(0.5f* speed * Time.fixedDeltaTime, 0, 0));
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Transform>().Translate(new Vector3(-0.5f* speed * Time.fixedDeltaTime,0,0));
            
            }
            else if (Input.GetKey(KeyCode.UpArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0,0.5f* speed * Time.fixedDeltaTime,0));
                }

              else if (Input.GetKey(KeyCode.DownArrow))
                {
                    GetComponent<Transform>().Translate(new Vector3(0,-0.5f* speed * Time.fixedDeltaTime,0));
                }
                else
                {
                    //GetComponent<Animator>().Play("Idle");
                }
    }
}

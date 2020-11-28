using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   private bool mouse_over = false;
   public static MouseOver Instance;
   public bool onUI;
      void Awake() {
        Instance = this;
    }
    void Start() {
        onUI = false;
    }
    void Update()
    {
        //Debug.Log(onUI);
        if (mouse_over)
        {
            onUI = true;
           // Debug.Log("Mouse Over");
            // Ploughing.Instance.canDig = false;
            // Fishing.Instance.canFish = false;
        }else{
            onUI = false;
            
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        //Debug.Log("Mouse enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
      // Debug.Log("Mouse exit");
    }
}

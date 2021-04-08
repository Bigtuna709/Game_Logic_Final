using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    public bool IsPressed
    {
        get;
        private set;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Checks to see if the gamobject is clicked, if so it makes the IsPressed bool true
        IsPressed = true;
    }

    //Turns the IsPressed bool false when the mouse button is released 
    public void OnPointerUp(PointerEventData eventData)
    {
        
        IsPressed = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        IsPressed = false;
    }
}

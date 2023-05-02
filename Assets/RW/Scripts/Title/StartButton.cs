using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //NEW
using UnityEngine.SceneManagement; //NEW

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    //NEdded to receive the class IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData) // 1
    {
        Application.Quit();
    }
}

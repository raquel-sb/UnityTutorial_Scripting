using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //NEW
using UnityEngine.SceneManagement; //NEW

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    //NEdded to receive the class IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData) // 1
    {
        SceneManager.LoadScene("Game"); // 2
    }
}

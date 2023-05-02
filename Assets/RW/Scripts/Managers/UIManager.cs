using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 1

    public Text sheepSavedText; // 2
    public Text sheepDroppedText; // 3
    public GameObject gameOverWindow; // 4

    // Awake is called before the Start methods
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved() // 1
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // 2
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}

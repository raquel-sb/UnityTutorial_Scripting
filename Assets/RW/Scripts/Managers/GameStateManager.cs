using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //New

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector] public int sheepSaved; // 2
    [HideInInspector] public int sheepDropped; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5

    // Awake is called before the Start methods
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //When the Escape key is pressed, SceneManager gets called and loads the title screen scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    //Update Sheep counter of saved sheeps
    public void SavedSheep()
    {
        sheepSaved++;

        //UIManager functionality
        UIManager.Instance.UpdateSheepSaved();
    }

    //Gets called every time a sheep falls down
    public void DroppedSheep()
    {
        sheepDropped++; // 1

        //UIManager functionalities
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) // 2
        {
            GameOver();
        }
    }

    //Will get called when too many sheep bite the dust
    private void GameOver()
    {
        sheepSpawner.canSpawn = false; // 1
        sheepSpawner.DestroyAllSheep(); // 2

        //UIManager
        UIManager.Instance.ShowGameOverWindow();
    }
}

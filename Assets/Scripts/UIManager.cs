using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class UIManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject EndButton;

    public GameObject Instructions;
    public GameObject Properties;

    public Canvas StartExitButtons;
    public Canvas InstructionsUI;
    public Canvas PropertiesTabUI;

    private bool MouseUnlock;

    public FreeCamLook freeCamLook;
    void Start()
    {
        InstructionsUI.enabled = false;
        PropertiesTabUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Inputs

        //This is to unlock the mouse cursor for players to access the Properties sliders or any other activity
        if (Input.GetKeyDown(KeyCode.Tab) && !MouseUnlock)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MouseUnlock = true;
            freeCamLook.canLook = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && MouseUnlock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MouseUnlock = false;
            freeCamLook.canLook = true;
        }

        //Exit game
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void StartButtonPressed()
    {
        //For when the player presses the start button
        freeCamLook.canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        InstructionsUI.enabled = true;
        PropertiesTabUI.enabled = true;
        StartExitButtons.enabled = false;
        

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

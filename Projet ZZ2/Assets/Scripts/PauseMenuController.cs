using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;                // Application en pause ou non

    public GameObject pauseMenuUI;                      // Référence au menu de pause 
    public GameObject gameUI;                           // Référence à l'interface de l'appli

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))           // Détecte l'appui sur la touche ECHAP
        {
            Debug.Log("Appui sur touche Escape");   
            if(isPaused)                                // Si le jeu est déjà en pause, on reprend l'application
            {
                Debug.Log("Reprise");
                Resume();
            }
            else                                        // Sinon on met en pause l'application
            {
                Debug.Log("Pause");
                Pause();
            }
        }
    }

    // Sort l'application de la pause
    public void Resume()
    {
        Debug.Log("resume");
        pauseMenuUI.SetActive(false);   // Mise en pause du menu de pause
        gameUI.SetActive(true);         // Activation du menu de l'appli
        Time.timeScale = 1f;            // Mise de temps de jeu à 1
        isPaused = false;               // L'appli n'est plus en pause
    }

    // Mets en pause l'application
    void Pause()
    {
        gameUI.SetActive(false);        // Mise en pause du menu de l'appli
        pauseMenuUI.SetActive(true);    // Activation du menu de pause
        Time.timeScale = 0f;            // Mise de temps de jeu à 0
        isPaused = true;                // L'appli est en pause
    }

    public void Quit()
    {
        Debug.Log("Fermeture de l'application...");
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Debug.Log("Chargement du menu");
        SceneManager.LoadScene("StartScene");
    }

    
}

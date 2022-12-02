using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Changement de scene active
    public void ChangeScene(string _sceneName)
    {
        Debug.Log("Changement de scene -> " + _sceneName);
        SceneManager.LoadScene( _sceneName );
    }

    // Fermeture de l'application
    public void Quit()
    {
        Debug.Log("Fermeture...");
        Application.Quit();
    }
}

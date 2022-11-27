using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Console.WriteLine("Touche Escape appuyée");
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("StarScene"));
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync("StartScene");
            //EditorSceneManager.OpenScene("StartScene");
        }


    }
}

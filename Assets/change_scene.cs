using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;


public class change_scene : MonoBehaviour
{
   
    public void LoadScene(string scene_name)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene_name);
        
        // Debug.Log(scene_name);
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene_name);
        // while (!asyncLoad.isDone)
        // {
        //     //do loading stuff on screen
        //     Debug.Log("loading");
        // }
        // if (asyncLoad.isDone)
        // {
        //     SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));
        //     AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(currentScene.name);
        //     if (asyncUnload.isDone)
        //     {
        //         Debug.Log("unloaded scene successfully");
        //         //Resources.UnloadUnusedAssets();
        //     }
        // }
        

    }

}

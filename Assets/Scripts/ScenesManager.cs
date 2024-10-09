using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// needed to reinitialize the ar sessions!
using UnityEngine.XR.ARFoundation;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    public static bool ShowNextButton;

    // ar sessions reset!
    [SerializeField]
    private ARSession _arSession;


    // new : also handles the audio plays inside a scene!
    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        audio = GetComponent<AudioSource>();
        // hide next button initially until the sound has been fully played
        ShowNextButton = false;
    }

    public enum Scene {
        MainMenuScene, //index 0
        HuntIntro,
        Hunt01,  //index 1
        Hunt01AR,
        Hunt02,
        Hunt02AR
        /**
        Hunt03,
        Hunt04,
        Hunt05,
        HuntDone
        **/
    }

    public void LoadScene(Scene scene)
    {
        _arSession.Reset();
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNextScene()
    {
        _arSession.Reset();
        if(SceneManager.GetActiveScene().buildIndex < Scene.GetNames(typeof(Scene)).Length-1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else {
            SceneManager.LoadScene(Scene.MainMenuScene.ToString());
        } 
    }

    public void LoadPreviousScene()
    {
        _arSession.Reset();
        if(SceneManager.GetActiveScene().buildIndex > 1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }else {
            SceneManager.LoadScene(Scene.MainMenuScene.ToString());
        } 
    }

    public void LoadMainMenu()
    {
        _arSession.Reset();
        SceneManager.LoadScene(Scene.MainMenuScene.ToString());
    }


    // in order to also play the file to the end, when the prefab is gone, the sound module is now part of the 
    // scenemanager
    public void StartSound(AudioClip fileToPlay)
    {
        audio.PlayOneShot(fileToPlay, 1f);
        float audioDuration = fileToPlay.length;
        NextButtonShowDelay(audioDuration);
        ShowNextButton = true;
    }

    IEnumerator NextButtonShowDelay(float waitDuration)
    {
        // Suspends the coroutine execution for the given amount of seconds using unscaled time.
        yield return new WaitForSeconds(waitDuration);
    }

}

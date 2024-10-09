using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _dropChapter;
    [SerializeField] Button _manualFirstSceneButton;
    [SerializeField] Button _exitButton;

    // Start is called before the first frame update
    void Start()
    {
        _manualFirstSceneButton.onClick.AddListener(StartFirstScene);
        _exitButton.onClick.AddListener(ExitApp);
    }

    public void dropChanged() {
        switch(_dropChapter.value){
            case 1:
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.HuntIntro);
                break;
            case 2: 
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.Hunt01);
                break;
            case 3:
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.Hunt02);
                break;
            /**
            case 4:
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.Hunt04);
                break;
            case 5:
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.Hunt05);
                break;
            case 6:
                ScenesManager.Instance.LoadScene(ScenesManager.Scene.HuntDone);
                break;
            **/

        }
    }

    private void StartFirstScene()
    {
        ScenesManager.Instance.LoadNextScene();
    }

    private void ExitApp()
    {
        Application.Quit();
    }
}

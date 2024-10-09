using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button _backButton;   
    [SerializeField] Button _nextButton;
    [SerializeField] Button _previousButton;
    // Start is called before the first frame update
    void Start()
    {
        _backButton.onClick.AddListener(GoToMainMenu);
        _nextButton.onClick.AddListener(GoToNextScene);
        _previousButton.onClick.AddListener(GoToPreviousScene);

        _nextButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        _nextButton.gameObject.SetActive(ScenesManager.ShowNextButton);
    }

    private void GoToMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }

    private void GoToNextScene()
    {
        ScenesManager.Instance.LoadNextScene();
    }

    private void GoToPreviousScene()
    {
        ScenesManager.Instance.LoadPreviousScene();
    }
}

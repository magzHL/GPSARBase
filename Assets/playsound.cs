using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playsound : MonoBehaviour
{

    // we need the component
    //AudioSource audio;
    [SerializeField] Button _playButton;
    [SerializeField] AudioClip _fileToPlay;
    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
        _playButton.onClick.AddListener(StartSound);
    }

    // Update is called once per frame
    private void StartSound()
    {
        //audio.PlayOneShot(_fileToPlay, 1f);
        ScenesManager.Instance.StartSound(_fileToPlay);
    }
}

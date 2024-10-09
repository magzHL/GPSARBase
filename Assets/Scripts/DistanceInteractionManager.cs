using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class DistanceInteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] TMP_Text _infoText;
    [SerializeField] GameObject _additionalPrefab;
    [SerializeField] string _presenceImg1;
    [SerializeField] string _presenceImg2;

    GameObject _additionalSpawnedPrefab;

    bool _img1Here = false;
    bool _img2Here = false;

    bool _additionalCreated = false;

    Vector3 _img1Pos;
    Vector3 _img2Pos;
    Vector3 _additionalSpawnedPos;

    Quaternion _img1Rot;
    Quaternion _img2Rot;
    Quaternion _additionalSpawnedRot;

    ARTrackedImageManager m_TrackedImageManager;
    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_infoText.text = "# Tracked: " + NumberOfTrackedImages().ToString()+"\n";
        //_infoText.text += NamesOfTrackedImages();
        CheckImg2Presence();
        CheckImg1Presence();
        PlaceAdditionalPrefab();
    }

    int m_NumberOfTrackedImages = 0;
    public int NumberOfTrackedImages()
    {
        m_NumberOfTrackedImages = 0;
        foreach (ARTrackedImage image in m_TrackedImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                m_NumberOfTrackedImages++;
            }
        }
        return m_NumberOfTrackedImages;
    }

    string m_NamesOfTrackedImages;
    public string NamesOfTrackedImages()
    {
        m_NamesOfTrackedImages = " : ";
        foreach (ARTrackedImage image in m_TrackedImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                m_NamesOfTrackedImages+= image.referenceImage.name.ToString() +" : ";
            }
        }
        return m_NamesOfTrackedImages;
    }

    public void CheckImg1Presence()
    {
        foreach (ARTrackedImage image in m_TrackedImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking && image.referenceImage.name.ToString() == _presenceImg1)
            {
                _img1Here = true;
                _img1Rot = image.transform.rotation;
                _img1Pos = image.transform.position;
            }
            if (image.trackingState != TrackingState.Tracking && image.referenceImage.name.ToString() == _presenceImg1)
            { 
                _img1Here = false; 
            }
        }
    }

    public void CheckImg2Presence()
    {
        foreach (ARTrackedImage image in m_TrackedImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking && image.referenceImage.name.ToString() == _presenceImg2)
            {
                _img2Here = true;
                _img2Rot = image.transform.rotation;
                _img2Pos = image.transform.position;
            }
            if (image.trackingState != TrackingState.Tracking && image.referenceImage.name.ToString() == _presenceImg2)
            {
                _img2Here = false;
            }
        }
    }

    public void PlaceAdditionalPrefab()
    {
        // show additional prefab in the middle!
        if(_img2Here && _img1Here)
        {
            //_additionalSpawnedPrefab = Instantiate(_additionalPrefab, image.transform.position, image.transform.rotation);
            _additionalSpawnedPos = (_img2Pos) * 1/7 + (_img1Pos) * 6/7; //(_img2Pos + _img1Pos) / 2;
            _additionalSpawnedRot = _img2Rot;
            if (_additionalCreated == false)
            {
                _additionalSpawnedPrefab = Instantiate(_additionalPrefab, _additionalSpawnedPos, _additionalSpawnedRot);
                _additionalCreated = true;
            }
            _additionalSpawnedPrefab.transform.SetPositionAndRotation(_additionalSpawnedPos, _additionalSpawnedRot);
            _additionalSpawnedPrefab.SetActive(true);
            //_infoText.text += "\n" + " : PAP auch!";
        } else
        {
            _additionalSpawnedPrefab.SetActive(false);
        }
    }
}

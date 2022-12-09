using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    private void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ?
            _iOSAdUnitId :
            _androidAdUnitId;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForAdvertisementReady());
    }

    IEnumerator WaitForAdvertisementReady()
    {
        yield return new WaitUntil(() => Advertisement.isInitialized);
        LoadAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"{placementId} has been loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"{placementId} failed to load: {error.ToString()} - {message}");
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"{placementId} failed to show: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void LoadAd()
    {
        Debug.Log("Loading ad..." + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing All: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);

        LoadAd();
    }
}

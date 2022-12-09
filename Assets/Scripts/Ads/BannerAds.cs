using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BannerAds : MonoBehaviour
{
    [SerializeField] Button _showBannerBtn;
    [SerializeField] Button _hideBannerBtn;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId;
    private void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ?
            _iOSAdUnitId :
            _androidAdUnitId;
    }


    void Start()
    {
        _showBannerBtn.interactable = false;
        _hideBannerBtn.interactable = false;
        //Change Position
        Advertisement.Banner.SetPosition(BannerPosition.CENTER);
        StartCoroutine(WaitForAdvertisementReady());
    }

    IEnumerator WaitForAdvertisementReady()
    {
        yield return new WaitUntil(() => Advertisement.isInitialized);
        LoadBanner();
    }


    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = LoadCallback,
            errorCallback = ErrorCallback

        };
        Advertisement.Banner.Load(_adUnitId, options);

    }

    void LoadCallback()
    {
        Debug.Log($"banner has been loaded");
        _showBannerBtn.interactable = true;
    }
    void ErrorCallback(string message)
    {
        Debug.Log($"banner failed to load: {message}");

    }

    public void ShowBanner()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClick,
            showCallback = OnBannerShown,
            hideCallback = OnBannerHidden
        };
        Advertisement.Banner.Show(_adUnitId, options);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    void OnBannerClick()
    {
        
    }

    void OnBannerShown()
    {
        _showBannerBtn.interactable = false;
        _hideBannerBtn.interactable = true;
    }

    void OnBannerHidden()
    {
        _showBannerBtn.interactable = true;
        _hideBannerBtn.interactable = false;
    }
}

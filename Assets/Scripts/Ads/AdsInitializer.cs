using UnityEngine;
using UnityEngine.Advertisements;
 [RequireComponent(typeof(RewardedAdsButton))]
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private bool testMode = true;
    private RewardedAdsButton _rewardedAdsButton;
    private string _gameId;
 
    void Awake()
    {
        Debug.Log("AAAAAAAAAA");
        _rewardedAdsButton = GetComponent<RewardedAdsButton>();
        InitializeAds();
    }
 
    public void InitializeAds()
    {
        _gameId = androidGameId;
        Advertisement.Initialize(_gameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        _rewardedAdsButton.LoadAd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

}
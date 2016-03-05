using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class FullScreenAd : MonoBehaviour
{
	InterstitialAd interstitial;
	public Button startButton;
	// Use this for initialization
	void Start ()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1847727001534987/5807200152";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the top of the screen.
		//bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		// Create an empty ad request.
		//	AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		//	bannerView.LoadAd(request);
		//	bannerView.Show();
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		startButton.onClick.AddListener(()=>{
			interstitial.Show();
		});

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}


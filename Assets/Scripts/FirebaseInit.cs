using Firebase;
using Firebase.Analytics;
using Firebase.Firestore;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        });
    }
}

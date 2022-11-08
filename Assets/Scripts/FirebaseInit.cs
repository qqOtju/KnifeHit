using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
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
            /*DocumentReference docRef = db.Collection("Records").Document("Oleg");*/
            /*docRef.SetAsync("123").ContinueWithOnMainThread(task1 =>
            {
                Debug.Log("DATA ADDED");
            });*/
        });
    }
}

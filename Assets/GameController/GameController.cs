using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public RoadCheck carCheck;
    public Text timeLeftText;
    public Text getBackOnRoadText;
    public float maxOffTrackTime = 2;
    public float currentOffTrackTime;

    bool last = false;
    void Update()
    {
        bool next = carCheck.IsOnRoad();
        if (next && !last) OnTrack(); 
        if (!next && last) OffTrack();
        last = next;
        if (!next) currentOffTrackTime = Mathf.Max(currentOffTrackTime - Time.deltaTime, 0);

        if (currentOffTrackTime <= 0) OnTimeout();
        timeLeftText.text = currentOffTrackTime.ToString("F2");
    }

    void OffTrack() {
        currentOffTrackTime = maxOffTrackTime;
        timeLeftText.gameObject.SetActive(true);
        getBackOnRoadText.gameObject.SetActive(true);
    }

    void OnTrack() {
        timeLeftText.gameObject.SetActive(false);
        getBackOnRoadText.gameObject.SetActive(false);
        currentOffTrackTime = maxOffTrackTime;
    }

    void OnTimeout() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

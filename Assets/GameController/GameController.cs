using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Off Track Things")]
    public RoadCheck carCheck;
    public Text timeLeftText;
    public Text getBackOnRoadText;
    public float maxOffTrackTime = 2;
    public float currentOffTrackTime;
    ObserveChange onTrackState;
    [Header("Backwards Things")]
    ObserveChange backwardsState;
    public float maxBackwardTime = 2;
    public float currentBackwardTime;
    public Track track;
    public Car.Car car;

    void Start()
    {
        onTrackState = new ObserveChange();
        backwardsState = new ObserveChange();
        currentOffTrackTime = maxOffTrackTime;
        currentBackwardTime = maxBackwardTime;
    }

    void FixedUpdate()
    {
        HandleOnTrackCheck();
        HandleBackwardsCheck();
    }

    void HandleBackwardsCheck()
    {

        backwardsState.Update(!track.IsMovingForward(car.rigidbody));

        if (backwardsState.IsJustOff()) OnCarForwards();
        if (backwardsState.IsJustOn()) OnCarBackwards();

        if (backwardsState.Current()) currentBackwardTime = Mathf.Max(currentBackwardTime - Time.deltaTime, 0);
        if (currentBackwardTime <= 0) ResetScene();
    }

    void HandleOnTrackCheck()
    {
        onTrackState.Update(carCheck.IsOnRoad());

        if (onTrackState.IsJustOff()) OnCarOffTrack();
        if (onTrackState.IsJustOn()) OnCarOnTrack();

        if (!onTrackState.Current()) currentOffTrackTime = Mathf.Max(currentOffTrackTime - Time.deltaTime, 0);
        if (currentOffTrackTime <= 0) ResetScene();
        timeLeftText.text = currentOffTrackTime.ToString("F2");
    }

    void OnCarBackwards()
    {
        currentBackwardTime = maxBackwardTime;
    }

    void OnCarForwards()
    {
        currentBackwardTime = maxBackwardTime;
    }


    void OnCarOffTrack()
    {
        currentOffTrackTime = maxOffTrackTime;
        timeLeftText.gameObject.SetActive(true);
        getBackOnRoadText.gameObject.SetActive(true);
    }

    void OnCarOnTrack()
    {
        timeLeftText.gameObject.SetActive(false);
        getBackOnRoadText.gameObject.SetActive(false);
        currentOffTrackTime = maxOffTrackTime;
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

class ObserveChange
{

    bool lastState;
    bool currentState;

    public ObserveChange(bool initialState = false)
    {
        this.currentState = initialState;
        this.lastState = initialState;
    }

    public void Update(bool newState)
    {
        lastState = currentState;
        currentState = newState;
    }

    public bool Current()
    {
        return currentState;
    }

    public bool IsJustOff()
    {
        return !currentState && lastState;
    }

    public bool IsJustOn()
    {
        return currentState && !lastState;
    }
}
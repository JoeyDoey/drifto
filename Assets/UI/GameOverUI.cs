using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public Transform UIContainer;
    public UISlideIn container;
    public bool enableContainerOnAwake = true;

    void Awake()
    {
        if (enableContainerOnAwake) {
            container.gameObject.SetActive(true);
        }
    }

    public void Play() {
        container.Play();
    }
}

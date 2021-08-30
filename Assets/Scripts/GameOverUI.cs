using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public Transform UIContainer;

    // Start is called before the first frame update
    void Start()
    {
        UIContainer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable() {
        UIContainer.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClippingPointUI : MonoBehaviour
{
    public GameObject textPrefab;
    public Vector3 positionOffset = Vector3.up * 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScore(AClippingPoint clippingPoint, float score) {
        ShowScore(clippingPoint.transform.position, score);
    }

    public void ShowScore(Vector3 position, float score) {
        GameObject textObj = Instantiate(textPrefab, transform);
        textObj.GetComponent<TextMeshProUGUI>().text = "+" + score;
        textObj.GetComponent<RectTransform>().position = position + positionOffset;
    }
}

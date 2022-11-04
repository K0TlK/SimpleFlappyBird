using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GetData : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        text.text = $"Time: {GameTimer.Instance.TimeInt}\n" +
                    $"Attempts: {GameManager.Instance.Attempts}\n";
    }
}

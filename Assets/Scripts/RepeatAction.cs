using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatAction: MonoBehaviour
{
    [SerializeField] private float timeDelay = 15.0f;
    private int count = 0;
    private int invokeCount = 0;
    private bool isActive = false;

    public event UnityAction DelayAction;
    public int Count => count;

    private void Start()
    {
        if (timeDelay < 5.0f)
        {
            Debug.LogError($"[RepeatAction] Little delay {timeDelay} < 5.0f");
        }
        GameTimer.Instance.Restart += Restart;
        GameTimer.Instance.Stop += Stop;
    }

    private void Restart()
    {
        count = 0;
        invokeCount = 0;
        isActive = true;
    }

    private void Stop()
    {
        isActive = false;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        count = Mathf.FloorToInt(GameTimer.Instance.Time / timeDelay);

        while (count > invokeCount)
        {
            invokeCount++;
            DelayAction.Invoke();
        }
    }
}

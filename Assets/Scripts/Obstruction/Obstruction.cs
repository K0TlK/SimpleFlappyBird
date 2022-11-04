using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstruction : MonoBehaviour
{
    public virtual void Init()
    {
    }

    [SerializeField] private Transform enterPoint;
    [SerializeField] private Transform exitPoint;
    private bool isComplete = false;
    public Vector3 EnterPoint => enterPoint.localPosition;
    public Vector3 ExitPoint => exitPoint.localPosition;
    public Vector3 EnterPointGlobal => enterPoint.position;
    public Vector3 ExitPointGlobal => exitPoint.position;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isComplete)
        {
            return;
        }

        isComplete = true;
        LevelBuilder.Instance.NextStep();
    }
}

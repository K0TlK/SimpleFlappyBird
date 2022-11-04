using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class MovableBlocks : Obstruction
{
    [SerializeField] private Transform block;
    private Sequence sequence;

    public override void Init()
    {
        sequence = DOTween.Sequence();
        int count = Random.Range(2, 5);
        for (int i = 0; i < count; i++)
        {
            sequence.Append(block.DOMove(block.position - 
                new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-3.5f, 3.5f), 0), 2.0f));
        }
        sequence.Append(block.DOMove(block.position, 2.0f));
        sequence.SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}

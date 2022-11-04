using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D))]
public class Barrier : Obstruction
{
    [SerializeField] private Wall partOne, partTwo;
    private static readonly float minOffset = 1f, maxOffset = 3f;

    public override void Init()
    {
        Vector3 newOffset = new Vector3(0, Random.Range(minOffset, maxOffset));
        partOne.transform.position -= newOffset;
        partTwo.transform.position += newOffset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlocks : Obstruction
{
    [SerializeField] private Transform[] blocks;
    [SerializeField] private float speed = 4;

    private void Update()
    {
        foreach (var block in blocks)
        {
            Vector3 rotate = block.rotation.eulerAngles;
            rotate.z += speed * Time.deltaTime;
            block.rotation = Quaternion.Euler(rotate);
        }
    }
}

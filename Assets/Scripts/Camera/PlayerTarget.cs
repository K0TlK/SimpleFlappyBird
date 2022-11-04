using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    private Transform player;

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 oldPos = transform.position;
        transform.position = new Vector3(player.position.x, oldPos.y, oldPos.z);
    }

    public void SetTarget(Transform obj)
    {
        player = obj;
    }
}

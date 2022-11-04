using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RepeatAction))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float speedAdd = 1.2f;
    private bool isActive = false;
    private float verticalModif = 1.0f;
    private float difficultyMultiplier = 1.0f;

    public bool IsActive
    {
        get { return isActive; }
        set { SetActive(value); }
    }

    private bool isFalling => !((Input.touchCount > 0) || Input.GetMouseButton(0));

    private void Start()
    {
        RepeatAction action = GetComponent<RepeatAction>();
        action.DelayAction += AddSpeed;
    }

    private void AddSpeed()
    {
        verticalModif += speedAdd;
    }

    private void SetActive(bool value)
    {
        if (value)
        {
            verticalModif = 1.0f;
            difficultyMultiplier = DifficultController.Instance.DifficultMultiplier;
        }

        isActive = value;
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        Vector2 newPos = transform.position;

        newPos += (isFalling ? Vector2.down : Vector2.up) * speed * verticalModif * difficultyMultiplier * Time.deltaTime;
        newPos += Vector2.right * difficultyMultiplier * speed * Time.deltaTime;
        transform.position = newPos;
    }
}

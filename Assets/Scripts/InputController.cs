using System;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour,IDeltaMove
{
    public Vector2 deltaMove { get; private set; }

    public Vector2 mouseWorldPos { get; private set; }

    public event Action<int> OnNumberPressed;

    public event Action OnShoot;

    [SerializeField] private Camera camera; 


    private void Update()
    {
        deltaMove = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            deltaMove += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            deltaMove += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            deltaMove += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            deltaMove += Vector2.right;
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }

        mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 1; i < 10; i++)
        {
            if (Input.GetKeyDown((KeyCode)(48 + i)))
            {
                OnNumberPressed?.Invoke(i);
            }
        }
    }
}

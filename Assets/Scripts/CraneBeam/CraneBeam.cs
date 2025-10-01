using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CraneBeam : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    [Header("Beam Settings")]
    [SerializeField] private Transform beamHolder;
    [SerializeField] private float speedBeam;
    [SerializeField] private float beamLimitMax;
    [SerializeField] private float beamLimitMin;

    [Header("Crane Settings")]
    [SerializeField] private Transform crane;
    [SerializeField] private float speedcrane;
    [SerializeField] private float craneLimitMax;
    [SerializeField] private float craneLimitMin;

    [Header("Hook Settings")]
    [SerializeField] private Transform hook;
    [SerializeField] private Transform winch;
    [SerializeField] private float speedhook;
    [SerializeField] private float hookLimitMax;
    [SerializeField] private float hookLimitMin;

    private Vector3 dir;

    private void OnEnable()
    {
        gameManager.OnControllerButtonDownChanged += ControllerButtonDownChanged;
        gameManager.OnControllerButtonUpChanged += ControllerButtonUpChanged;
    }

    private void OnDisable()
    {
        gameManager.OnControllerButtonDownChanged -= ControllerButtonDownChanged;
        gameManager.OnControllerButtonUpChanged -= ControllerButtonUpChanged;
    }

    private void ControllerButtonDownChanged(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.up:
                dir = Vector3.up;
                break;
            case ButtonType.down:
                dir = Vector3.down;
                break;
            case ButtonType.right:
                dir = Vector3.left;
                break;
            case ButtonType.left:
                dir = Vector3.right;
                break;
            case ButtonType.forward:
                dir = Vector3.back;
                break;
            case ButtonType.back:
                dir = Vector3.forward;
                break;
        }
    }

    private void ControllerButtonUpChanged(ButtonType type)
    {
        dir = Vector3.zero;
    }

    private void Update()
    {
        Move(dir);
    }

    private void Move(Vector3 direction)
    {
        if (direction.z != 0)
        {
            float translation = direction.z * speedBeam * Time.deltaTime;

            beamHolder.localPosition += new Vector3(beamHolder.localPosition.x, beamHolder.localPosition.y, translation);

            float currentPosition = beamHolder.localPosition.z;
            currentPosition = Mathf.Clamp(currentPosition, beamLimitMin, beamLimitMax);
            beamHolder.localPosition = new Vector3(beamHolder.localPosition.x, beamHolder.localPosition.y, currentPosition);
        }
        else if (direction.x != 0)
        {
            float translation = direction.x * speedcrane * Time.deltaTime;

            crane.localPosition += Vector3.right * translation;

            float currentPosition = crane.localPosition.x;
            currentPosition = Mathf.Clamp(currentPosition, craneLimitMin, craneLimitMax);
            crane.localPosition = new Vector3(currentPosition, crane.localPosition.y, crane.localPosition.z);
        }
        else if (direction.y != 0)
        {
            float translation = direction.y * speedhook * Time.deltaTime;

            hook.localPosition += Vector3.up * translation;

            if (hook.localPosition.y > hookLimitMin && hook.localPosition.y < hookLimitMax)
            {
                winch.Rotate(Vector3.right * translation * 100f);
            }

            float currentPosition = hook.localPosition.y;
            currentPosition = Mathf.Clamp(currentPosition, hookLimitMin, hookLimitMax);
            hook.localPosition = new Vector3(hook.localPosition.x, currentPosition, hook.localPosition.z);
        }
    }
}

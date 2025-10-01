using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<ButtonType> OnControllerButtonDownChanged;
    public event Action<ButtonType> OnControllerButtonUpChanged;
    public event Action<Transform, Transform> OnTakeObjectChanged;
    public event Action OnTurnDeviceChanged;
    public event Action<Vector3> OnDistanceDangerZoneChanged;

    public void ControllerButtonDownInvoke(ButtonType buttonType) => OnControllerButtonDownChanged?.Invoke(buttonType);

    public void ControllerButtonUpInvoke(ButtonType buttonType) => OnControllerButtonUpChanged?.Invoke(buttonType);

    public void TakeObject(Transform analyzer, Transform probe) => OnTakeObjectChanged?.Invoke(analyzer, probe);

    public void TurnDevice() => OnTurnDeviceChanged?.Invoke();

    public void DistanceDangerZoneUpdate(Vector3 position) => OnDistanceDangerZoneChanged?.Invoke(position);
}

public enum ButtonType
{
    up,
    down,
    right,
    left,
    forward,
    back
}

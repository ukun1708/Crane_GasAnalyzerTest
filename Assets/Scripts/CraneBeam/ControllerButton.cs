using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ControllerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ButtonType buttonType;

    [Inject] private GameManager gameManager;

    public void OnPointerDown(PointerEventData eventData) => ButtonDown();

    public void OnPointerUp(PointerEventData eventData) => ButtonUp();

    private void ButtonDown()
    {
        gameManager.ControllerButtonDownInvoke(buttonType);
        print(buttonType.ToString());
    }

    private void ButtonUp()
    {
        gameManager.ControllerButtonUpInvoke(buttonType);
    }
}

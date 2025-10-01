using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class AnalyzerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Inject] private GameManager gameManager;

    [SerializeField]
    private Image turnTimerImage;

    private bool buttonDown;
    float timer;

    private void Awake()
    {
        buttonDown = false;
        timer = 0f;
        turnTimerImage.fillAmount = 0f;
    }

    private void Update()
    {
        if (buttonDown)
        {
            timer += Time.deltaTime;

            turnTimerImage.fillAmount = timer / 3f;

            if (timer >= 3)
            {
                buttonDown = false;
                timer = 0f;
                turnTimerImage.fillAmount = 0f;
                gameManager.TurnDevice();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
        timer = 0f;
        turnTimerImage.fillAmount = 0f;
    }
}

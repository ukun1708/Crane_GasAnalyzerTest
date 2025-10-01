using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class GazAnalyzer : MonoBehaviour, IPointerClickHandler
{
    private Rigidbody rbMain;
    private Collider colliderMain;

    [Inject] private GameManager gameManager;

    [SerializeField] private GameObject metrometer;
    [SerializeField] private TMP_Text metrometerText;
    [SerializeField] private Transform probe;    

    private void Awake()
    {
        rbMain = GetComponent<Rigidbody>();
        colliderMain = GetComponent<Collider>();
        metrometer.SetActive(false);
    }

    private void OnEnable()
    {
        gameManager.OnTurnDeviceChanged += TurnDevice;
        gameManager.OnDistanceDangerZoneChanged += DistanceDangerZoneCheck;
    }

    private void OnDisable()
    {
        gameManager.OnTurnDeviceChanged -= TurnDevice;
        gameManager.OnDistanceDangerZoneChanged -= DistanceDangerZoneCheck;
    }

    private void DistanceDangerZoneCheck(Vector3 dangerZoneDistance)
    {
        if (metrometer.activeSelf)
        {
            float distance = Vector3.Distance(dangerZoneDistance, probe.position);

            metrometerText.text = distance.ToString("0");
        }
    }

    private void TurnDevice()
    {
        if (metrometer.activeSelf)
        {
            metrometer.SetActive(false);
        }
        else
        {
            metrometer.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(rbMain);
        colliderMain.enabled = false;

        probe.GetComponent<Rigidbody>().isKinematic = true;
        probe.GetComponent<Collider>().enabled = false;

        gameManager.TakeObject(transform, probe);

        print("take Gaz Analyzer");
    }
}

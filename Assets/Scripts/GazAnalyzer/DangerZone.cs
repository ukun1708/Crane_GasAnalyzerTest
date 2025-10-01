using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DangerZone : MonoBehaviour
{
    [Inject] private GameManager gameManager;

    private void Update()
    {
        gameManager.DistanceDangerZoneUpdate(transform.position);
    }
}

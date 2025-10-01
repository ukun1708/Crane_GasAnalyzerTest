using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameManager gameManager;

    public override void InstallBindings()
    {
        Container.BindInstance(gameManager);
    }
}
using Configs;
using UnityEngine;
using Zenject;

namespace Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MoveLimit moveLimit = Resources.Load<MoveLimit>("Configs/MoveLimit");
            Container.Bind<MoveLimit>().FromInstance(moveLimit).AsSingle();
        }
    }
}

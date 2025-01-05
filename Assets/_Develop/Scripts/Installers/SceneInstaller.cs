using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MoveLimit moveLimit = Resources.Load<MoveLimit>("Configs/MoveLimit");
            Container.Bind<MoveLimit>().FromInstance(moveLimit).AsSingle();
            
            Stats stats = Resources.Load<Stats>("Configs/MeteorStats");
            Container.Bind<Stats>().FromInstance(stats).AsSingle();
        }
    }
}

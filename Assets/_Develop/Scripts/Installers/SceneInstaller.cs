using _Develop.Scripts.Character;
using _Develop.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        CharacterHealth _characterHealth;
        public override void InstallBindings()
        {
            MoveLimitSO moveLimitSo = Resources.Load<MoveLimitSO>("Configs/MoveLimit");
            Container.Bind<MoveLimitSO>().FromInstance(moveLimitSo).AsSingle();
            
            StatsMeteorSO statsMeteorSo = Resources.Load<StatsMeteorSO>("Configs/MeteorStats");
            Container.Bind<StatsMeteorSO>().FromInstance(statsMeteorSo).AsSingle();
            
            LaserBulletSO laserBulletSo = Resources.Load<LaserBulletSO>("Configs/LaserBullet");
            Container.Bind<LaserBulletSO>().FromInstance(laserBulletSo).AsSingle();
            
            CharacterStatsSO characterStatsSO = Resources.Load<CharacterStatsSO>("Configs/CharacterStats");
            Container.Bind<CharacterStatsSO>().FromInstance(characterStatsSO).AsSingle();
            
            Container.Bind<CharacterHealth>().FromInstance(_characterHealth).AsSingle();
        }
    }
}

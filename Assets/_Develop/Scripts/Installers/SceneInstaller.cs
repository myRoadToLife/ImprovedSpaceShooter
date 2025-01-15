using _Develop.Configs;
using _Develop.Scripts.Character;
using _Develop.Scripts.Character.MonoBeh;
using _Develop.Scripts.Common;
using _Develop.Scripts.UI;
using _Develop.Scripts.VFX;
using UnityEngine;
using Zenject;

namespace _Develop.Scripts.Installers
{
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Explosion _explosionPrefab;
        [SerializeField] private Animator _animator;
        [SerializeField] private PanelController _panelController;
        
        
        public override void InstallBindings()
        {
            MoveLimitSO moveLimitSo = Resources.Load<MoveLimitSO>("Configs/MoveLimit");
            Container.Bind<MoveLimitSO>().FromInstance(moveLimitSo).AsSingle();

            StatsMeteorSO statsMeteorSo = Resources.Load<StatsMeteorSO>("Configs/MeteorStats");
            Container.Bind<StatsMeteorSO>().FromInstance(statsMeteorSo).AsSingle();
            
            StatsShipsSO statsShipsSO = Resources.Load<StatsShipsSO>("Configs/StatsShips");
            Container.Bind<StatsShipsSO>().FromInstance(statsShipsSO).AsSingle();

            LaserBulletSO laserBulletSo = Resources.Load<LaserBulletSO>("Configs/LaserBullet");
            Container.Bind<LaserBulletSO>().FromInstance(laserBulletSo).AsSingle();

            CharacterStatsSO characterStatsSO = Resources.Load<CharacterStatsSO>("Configs/CharacterStats");
            Container.Bind<CharacterStatsSO>().FromInstance(characterStatsSO).AsSingle();
            
            Container.Bind<EnemiesSpawner>().FromComponentInHierarchy().AsSingle();
            
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();

            Container.Bind<CharacterHealth>().FromComponentInHierarchy().AsSingle();

            Container.Bind<HealthBarView>().FromComponentInHierarchy().AsSingle();

            Container.BindFactory<Vector3, Quaternion, Explosion, ExplosionFactory>()
                .FromComponentInNewPrefab(_explosionPrefab)
                .AsTransient();
            
            Container.Bind<Animator>().FromInstance(_animator).AsSingle();
            Container.Bind<CharacterAnimation>().AsSingle();

            Container.Bind<EndLevelManager>().AsSingle();
            Container.Bind<PanelController>().FromInstance(_panelController).AsSingle();
            
            Container.Bind<WinCondition>().AsSingle().NonLazy();
            
            Container.Bind<FadeCanvas>().FromComponentInHierarchy().AsSingle();
            
        }
    }
}

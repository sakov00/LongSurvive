using Assets.Scripts.Units.Models;
using Assets.Scripts.Units.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Привязываем зависимости
            Container.Bind<DiContainer>().FromInstance(Container);
            Container.Bind<EnemyModel>().AsTransient();
            Container.Bind<EnemyView>().AsTransient();
        }
    }
}

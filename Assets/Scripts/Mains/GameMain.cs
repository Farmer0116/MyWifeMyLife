using System;
using Systems.Interfaces;
using UnityEngine;
using Zenject;

namespace Mains
{
    [DefaultExecutionOrder(999)]
    public class GameMain : MonoBehaviour
    {
        private ITalkerSystem _talkerSystem;

        [Inject]
        private void construct
        (
            ITalkerSystem talkerSystem
        )
        {
            _talkerSystem = talkerSystem;
        }

        private async void Awake()
        {
            try
            {
                await _talkerSystem.Begin();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void Start()
        {
            // ========== 初期設定 ==========
        }

        private void OnDestroy()
        {
        }
    }
}



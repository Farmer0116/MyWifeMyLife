using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;
using System;
using Cores.UseCases.Interfaces;
using Cores.Models.Interfaces;

namespace Cores.UseCases
{
    public class CharacterTalkingUseCase : ICharacterTalkingUseCase
    {
        private ISpawningCharactersModel _spawningCharactersModel;
        private IPlayerConversationModel _playerConversationModel;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public CharacterTalkingUseCase
        (
            ISpawningCharactersModel spawningCharactersModel,
            IPlayerConversationModel playerConversationModel
        )
        {
            _spawningCharactersModel = spawningCharactersModel;
            _playerConversationModel = playerConversationModel;
        }

        public async UniTask Begin()
        {
            // キャラクタ追加イベント
            _spawningCharactersModel.OnAddCharacter.Subscribe(info =>
            {
                _playerConversationModel.OnTalkSubject.Subscribe(text =>
                {
                    info.Value.Listen(text);
                }).AddTo(_disposables);
            }).AddTo(_disposables);

            // Todo: List管理ならdisposeは要素自体（CharaModel）に持たせるべきじゃね？
        }

        public void Finish()
        {
            _disposables.Dispose();
        }
    }
}

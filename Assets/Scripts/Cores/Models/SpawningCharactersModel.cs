using System;
using Cores.Models.Interfaces;
using UniRx;

namespace Cores.Models
{
    /// <summary>
    /// 3D空間上に生成されているキャラクタのCharacterModelを管理するモデル
    /// </summary>
    public class SpawningCharactersModel : ISpawningCharactersModel
    {
        public ReactiveCollection<ICharacterModel> Characters { get { return _characters; } }
        public ReactiveCollection<ICharacterModel> _characters = new ReactiveCollection<ICharacterModel>();

        public IObservable<CollectionAddEvent<ICharacterModel>> OnAddCharacter { get { return _characters.ObserveAdd(); } }
        public IObservable<CollectionRemoveEvent<ICharacterModel>> OnRemoveCharacter { get { return _characters.ObserveRemove(); }}
    }
}

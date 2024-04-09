using System;
using UniRx;

namespace Cores.Models.Interfaces
{
    /// <summary>
    /// 3D空間上に生成されているキャラクタのCharacterModelを管理するモデル
    /// </summary>
    public interface ISpawningCharactersModel
    {
        ReactiveCollection<ICharacterModel> Characters { get; }

        IObservable<CollectionAddEvent<ICharacterModel>> OnAddCharacter { get; }
        IObservable<CollectionRemoveEvent<ICharacterModel>> OnRemoveCharacter { get; }
    }
}

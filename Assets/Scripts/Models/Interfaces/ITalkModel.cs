using System;
using UniRx;

namespace Models.Interfaces
{
  public interface ITalkModel : IBaseModel
  {
    ReactiveDictionary<Guid, TalkModelData> TalkerMap { get; }
  }
}
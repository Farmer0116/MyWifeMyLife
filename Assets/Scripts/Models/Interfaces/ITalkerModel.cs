using System;
using UniRx;

namespace Models.Interfaces
{
  public interface ITalkerModel : IBaseModel
  {
    ReactiveDictionary<Guid, TalkerProp> TalkerPropMap { get; }
  }
}
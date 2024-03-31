using System;
using UniRx;

namespace Models.Interfaces
{
  public interface IFollowModel : IBaseModel
  {
    ReactiveDictionary<Guid, FollowModelData> FollowMap { get; }
  }
}
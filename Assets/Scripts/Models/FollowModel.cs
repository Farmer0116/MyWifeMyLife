using Models.Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace Models
{
  public class FollowModel : IFollowModel
  {
    public ReactiveDictionary<Guid, FollowModelData> FollowMap { get { return _followMap; } }
    private readonly ReactiveDictionary<Guid, FollowModelData> _followMap = new ReactiveDictionary<Guid, FollowModelData>();
  }

  [Serializable]
  public class FollowModelData : BaseModeData
  {
    public GameObject Target;
    public Vector3 PositionOffset;
    public Vector3 EulerOffset;
  }
}

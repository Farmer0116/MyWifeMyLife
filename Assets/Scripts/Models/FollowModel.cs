using Models.Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace Models
{
  public class FollowModel : IFollowModel
  {
    public ReactiveDictionary<Guid, FollowProp> FollowPropMap { get { return _followPropMap; } }
    private readonly ReactiveDictionary<Guid, FollowProp> _followPropMap = new ReactiveDictionary<Guid, FollowProp>();
  }

  [Serializable]
  public class FollowProp : BaseProp
  {
    public GameObject Target;
    public Vector3 PositionOffset;
    public Vector3 EulerOffset;
  }
}

using Models.Interfaces;
using System;
using UniRx;

namespace Models
{
  public class TalkerModel : ITalkerModel
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public ReactiveDictionary<Guid, TalkerProp> TalkerPropMap { get { return _talkerPropMap; } }
    public ReactiveDictionary<Guid, TalkerProp> _talkerPropMap = new ReactiveDictionary<Guid, TalkerProp>();
  }

  [Serializable]
  public class TalkerProp : BaseProp
  {
    public float TalkSpeed;
    public float HearingRange;
  }
}

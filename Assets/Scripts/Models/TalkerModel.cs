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
    public ReactiveDictionary<Guid, TalkerModelData> TalkerMap { get { return _talkerMap; } }
    public ReactiveDictionary<Guid, TalkerModelData> _talkerMap = new ReactiveDictionary<Guid, TalkerModelData>();
  }

  [Serializable]
  public class TalkerModelData : BaseModeData
  {
    public float TalkSpeed;
    public float HearingRange;
  }
}

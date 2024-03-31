using Models.Interfaces;
using System;
using System.Collections.Generic;
using UniRx;

namespace Models
{
  public class TalkModel : ITalkModel
  {
    public ReactiveDictionary<Guid, TalkModelData> TalkerMap { get { return _talkerMap; } }
    public ReactiveDictionary<Guid, TalkModelData> _talkerMap = new ReactiveDictionary<Guid, TalkModelData>();
  }

  [Serializable]
  public class TalkModelData : BaseModeData
  {
    public float TalkSpeed;
    public float HearingRange;
    public List<string> ConversationHistory;
    public string NaturePrompt;
  }
}

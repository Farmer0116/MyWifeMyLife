using Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Models
{
    public class TalkerModel : ITalkerModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Dictionary<Guid, TalkerProp> TalkerPropMap { get { return _talkerPropMap; } }
        public Dictionary<Guid, TalkerProp> _talkerPropMap = new Dictionary<Guid, TalkerProp>();
    }

    [System.Serializable]
    public class TalkerProp : BaseProp
    {
        public float TalkSpeed;
        public float HearingRange;
    }
}

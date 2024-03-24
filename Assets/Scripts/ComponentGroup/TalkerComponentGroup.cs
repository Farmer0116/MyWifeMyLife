using ComponentGroup.Interfaces;
using Components;
using System;
using System.Collections.Generic;

namespace ComponentGroup
{
    public class TalkerComponentGroup : ITalkerComponentGroup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Dictionary<Guid, TalkerComponent> TalkerComponentMap { get { return _talkerComponentMap; } }
        public Dictionary<Guid, TalkerComponent> _talkerComponentMap = new Dictionary<Guid, TalkerComponent>();
    }
}

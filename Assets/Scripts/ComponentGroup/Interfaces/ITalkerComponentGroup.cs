using System;
using System.Collections.Generic;
using Components;

namespace ComponentGroup.Interfaces
{
    public interface ITalkerComponentGroup : IBaseComponentGroup
    {
        public Dictionary<Guid, TalkerComponent> TalkerComponentMap { get; }
    }
}
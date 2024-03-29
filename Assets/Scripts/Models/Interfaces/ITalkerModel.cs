using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface ITalkerModel : IBaseModel
    {
        public Dictionary<Guid, TalkerProp> TalkerPropMap { get; }
    }
}
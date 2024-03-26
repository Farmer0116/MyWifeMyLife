using System;
using UnityEngine;

namespace Entities
{
    public class EntityId : MonoBehaviour
    {
        public Guid Eid = Guid.NewGuid();
    }
}

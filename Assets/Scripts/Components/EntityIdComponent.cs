using System;
using UnityEngine;

namespace Entities
{
    public class EntityIdComponent : MonoBehaviour
    {
        public Guid Eid = Guid.NewGuid();
    }
}

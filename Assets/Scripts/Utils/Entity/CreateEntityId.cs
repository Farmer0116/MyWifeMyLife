using System;
using UnityEngine;

namespace Utils.Entity
{
    public class CreateEntityId : MonoBehaviour
    {
        public Guid Eid = Guid.NewGuid();
    }
}

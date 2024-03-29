using Entities;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(EntityId))]
    public abstract class BaseComponent : MonoBehaviour
    {
    }
}

using Entities;
using UnityEngine;

namespace Components.Mono
{
    [RequireComponent(typeof(EntityId))]
    public abstract class BaseComponent : MonoBehaviour
    {
    }
}

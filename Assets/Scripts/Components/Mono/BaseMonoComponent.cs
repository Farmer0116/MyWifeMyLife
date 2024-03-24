using UnityEngine;
using Utils.Entity;

namespace Components.Mono
{
    [RequireComponent(typeof(CreateEntityId))]
    public abstract class BaseComponent : MonoBehaviour
    {
    }
}

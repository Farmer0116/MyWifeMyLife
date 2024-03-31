using Entities;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(EntityIdComponent))]
    public abstract class BaseComponent : MonoBehaviour
    {
    }
}

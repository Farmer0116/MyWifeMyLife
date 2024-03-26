using System;
using ComponentGroup.Interfaces;
using Entities;
using UnityEngine;
using Zenject;

namespace Components.Mono
{
    public class TalkerMonoComponent : BaseComponent
    {
        [Inject] private ITalkerComponentGroup _talkerComponentGroup;
        [SerializeField] private TalkerComponent _talkerComponent = new TalkerComponent();
        private Guid _eid;
        private ZenAutoInjecter _injecter;

        void Awake()
        {
            _eid = GetComponent<EntityId>().Eid;

            if (_talkerComponentGroup != null)
            {
                _talkerComponentGroup.TalkerComponentMap.Add(_eid, _talkerComponent);
            }
            else
            {
                _injecter = gameObject.AddComponent<ZenAutoInjecter>();
                _talkerComponentGroup.TalkerComponentMap.Add(_eid, _talkerComponent);
            }
        }

        void OnDestroy()
        {
            _talkerComponentGroup.TalkerComponentMap.Remove(_eid);
            if (_injecter != null) Destroy(_injecter);
        }
    }
}
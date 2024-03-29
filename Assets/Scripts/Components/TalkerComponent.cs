using System;
using Models;
using Entities;
using UnityEngine;
using Zenject;
using Models.Interfaces;

namespace Components
{
    public class TalkerComponent : BaseComponent
    {
        [Inject] private ITalkerModel _talkerModel;
        [SerializeField] private TalkerProp _talkerProp = new TalkerProp();
        private Guid _eid;
        private ZenAutoInjecter _injecter;

        void Awake()
        {
            _eid = GetComponent<EntityId>().Eid;

            if (_talkerModel != null)
            {
                _talkerModel.TalkerPropMap.Add(_eid, _talkerProp);
            }
            else
            {
                _injecter = gameObject.AddComponent<ZenAutoInjecter>();
                _talkerModel.TalkerPropMap.Add(_eid, _talkerProp);
            }
        }

        void OnDestroy()
        {
            _talkerModel.TalkerPropMap.Remove(_eid);
            if (_injecter != null) Destroy(_injecter);
        }
    }
}
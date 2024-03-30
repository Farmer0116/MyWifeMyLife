using System;
using Models;
using Entities;
using UnityEngine;
using Zenject;
using Models.Interfaces;

namespace Components
{
    public class FollowComponent : BaseComponent
    {
        [Inject] private IFollowModel _followModel;
        [SerializeField] private FollowProp _followProp = new FollowProp();
        private Guid _eid;
        private ZenAutoInjecter _injecter;

        void Awake()
        {
            _eid = GetComponent<EntityId>().Eid;
            _followProp.Component = this;

            if (_followModel != null)
            {
                _followModel.FollowPropMap.Add(_eid, _followProp);
            }
            else
            {
                _injecter = gameObject.AddComponent<ZenAutoInjecter>();
                _followModel.FollowPropMap.Add(_eid, _followProp);
            }
        }

        void OnDestroy()
        {
            _followModel.FollowPropMap.Remove(_eid);
            if (_injecter != null) Destroy(_injecter);
        }
    }
}
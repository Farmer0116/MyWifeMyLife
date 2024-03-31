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
        [SerializeField] private FollowModelData _followModelData = new FollowModelData();
        private Guid _eid;
        private ZenAutoInjecter _injecter;

        void Awake()
        {
            _eid = GetComponent<EntityId>().Eid;
            _followModelData.Component = this;

            if (_followModel != null)
            {
                _followModel.FollowMap.Add(_eid, _followModelData);
            }
            else
            {
                _injecter = gameObject.AddComponent<ZenAutoInjecter>();
                _followModel.FollowMap.Add(_eid, _followModelData);
            }
        }

        void OnDestroy()
        {
            _followModel.FollowMap.Remove(_eid);
            if (_injecter != null) Destroy(_injecter);
        }
    }
}
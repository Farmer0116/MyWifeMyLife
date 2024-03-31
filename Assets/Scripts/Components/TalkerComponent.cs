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
    [SerializeField] private TalkerModelData _talkerModelData = new TalkerModelData();
    private Guid _eid;
    private ZenAutoInjecter _injecter;

    void Awake()
    {
      // 共通処理
      _eid = GetComponent<EntityId>().Eid;
      _talkerModelData.Component = this;

      if (_talkerModel != null)
      {
        _talkerModel.TalkerMap.Add(_eid, _talkerModelData);
      }
      else
      {
        _injecter = gameObject.AddComponent<ZenAutoInjecter>();
        _talkerModel.TalkerMap.Add(_eid, _talkerModelData);
      }
    }

    void OnDestroy()
    {
      _talkerModel.TalkerMap.Remove(_eid);
      if (_injecter != null) Destroy(_injecter);
    }
  }
}
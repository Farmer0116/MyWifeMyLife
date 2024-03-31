using System;
using Models;
using Entities;
using UnityEngine;
using Zenject;
using Models.Interfaces;

namespace Components
{
  public class TalkComponent : BaseComponent
  {
    [Inject] private ITalkModel _talkModel;
    [SerializeField] private TalkModelData _talkModelData = new TalkModelData();
    private Guid _eid;
    private ZenAutoInjecter _injecter;

    void Awake()
    {
      // 共通処理
      _eid = GetComponent<EntityIdComponent>().Eid;
      _talkModelData.Component = this;

      if (_talkModel != null)
      {
        _talkModel.TalkerMap.Add(_eid, _talkModelData);
      }
      else
      {
        _injecter = gameObject.AddComponent<ZenAutoInjecter>();
        _talkModel.TalkerMap.Add(_eid, _talkModelData);
      }
    }

    void OnDestroy()
    {
      _talkModel.TalkerMap.Remove(_eid);
      if (_injecter != null) Destroy(_injecter);
    }
  }
}
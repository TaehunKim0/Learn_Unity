using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseSkill : MonoBehaviour
{
    protected CharacterManager _characterManager;
    public float CooldownTime;
    private float _lastUsedTime; // 마지막으로 스킬을 사용한 시간

    public void Init(CharacterManager characterManager)
    {
        _characterManager = characterManager;
        this._lastUsedTime = -99f; // 초기화 시간을 설정하여 처음에는 스킬을 사용할 수 있도록 함
    }

    public bool IsAvailable()
    {
        // 스킬이 쿨다운 중인지 확인
        return Time.time - _lastUsedTime >= CooldownTime;
    }

    public virtual void Activate()
    {
        // 스킬 사용 시간 업데이트
        _lastUsedTime = Time.time;
    }
}
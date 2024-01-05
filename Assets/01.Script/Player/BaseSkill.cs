using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : BaseManager
{
    public float cooldownTime;
    private float lastUsedTime; // 마지막으로 스킬을 사용한 시간

    public void Init(string inName, float inCooldownTime)
    {
        this.name = inName;
        this.cooldownTime = inCooldownTime;
        this.lastUsedTime = -inCooldownTime; // 초기화 시간을 설정하여 처음에는 스킬을 사용할 수 있도록 함
    }

    public bool IsAvailable()
    {
        // 스킬이 쿨다운 중인지 확인
        return Time.time - lastUsedTime >= cooldownTime;
    }

    public virtual void Activate()
    {
        // 스킬 사용 시간 업데이트
        lastUsedTime = Time.time;
    }
}
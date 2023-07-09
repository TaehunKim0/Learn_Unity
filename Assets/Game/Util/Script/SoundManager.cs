using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Sound  // ������Ʈ �߰� �Ұ���.  MonoBehaviour ��� �� �޾Ƽ�. �׳� C# Ŭ����.
{
    public string name;  // �� �̸�
    public AudioClip clip;  // ��
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;  // �ڱ� �ڽ��� ���� �ڿ�����. static�� ���� �ٲ� �����ȴ�.

    [SerializeField] 
    private Sound[] SFXSounds;  // ȿ���� ����� Ŭ����

    [SerializeField]
    private Sound[] BgmSounds;  // BGM ����� Ŭ����

    [SerializeField]
    private AudioSource AudioSourceBgm;  // BGM �����. BGM ����� �� �������� �̷������ �ǹǷ� �迭 X 

    [SerializeField]
    private AudioSource[] AudioSourceSFX;  // ȿ�������� ���ÿ� �������� ����� �� �����Ƿ� 'mp3 �����'�� �迭�� ����

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(gameObject);  // �� �ٲ� �� �ڱ� �ڽ� �ı� ����
        }
        else
            Destroy(this.gameObject);
    }

    public void PlaySFX(string _name)
    {
        for (int i = 0; i < SFXSounds.Length; i++)
        {
            if (_name == SFXSounds[i].name)
            {
                for (int j = 0; j < AudioSourceSFX.Length; j++)
                {
                    if (false == AudioSourceSFX[j].isPlaying)
                    {
                        AudioSourceSFX[j].clip = SFXSounds[i].clip;
                        AudioSourceSFX[j].Play();
                        return;
                    }
                }
                Debug.Log("��� ���� AudioSource�� ��� ���Դϴ�.");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < BgmSounds.Length; i++)
        {
            if (_name == BgmSounds[i].name)
            {
                AudioSourceBgm.clip = BgmSounds[i].clip;
                AudioSourceBgm.Play();
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
    }

    public void StopAllSFX()
    {
        for (int i = 0; i < AudioSourceSFX.Length; i++)
        {
            AudioSourceSFX[i].Stop();
        }
    }
}

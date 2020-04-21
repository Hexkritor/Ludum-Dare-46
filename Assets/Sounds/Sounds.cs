using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string SoundAtt;
    [FMODUnity.EventRef]
    public string SoundDth;

    FMOD.Studio.EventInstance EventInstanceAtt;
    FMOD.Studio.EventInstance EventInstanceDth; // Переменная для инстанаса

    public void Sound_Att()
    {
        EventInstanceAtt = FMODUnity.RuntimeManager.CreateInstance(SoundAtt);//создаёт  контейнер для семпла
        EventInstanceAtt.start();//Проигрывает этот контейнер
        EventInstanceAtt.release();//Удаляет этот контейнер
    }

    public void Sound_Dth()
    {
        EventInstanceDth = FMODUnity.RuntimeManager.CreateInstance(SoundDth);//создаёт  контейнер для семпла
        EventInstanceDth.start();//Проигрывает этот контейнер
        EventInstanceDth.release();//Удаляет этот контейнер
    }
}

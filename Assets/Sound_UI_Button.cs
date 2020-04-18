using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_UI_Button : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string UI_Button_Sound; // Переменная для ивента

    FMOD.Studio.EventInstance EventInstance; // Переменная для инстанаса

    public void Play_UI_Sound()
    {
        EventInstance = FMODUnity.RuntimeManager.CreateInstance(UI_Button_Sound);//создаёт  контейнер для семпла
        EventInstance.start();//Проигрывает этот контейнер
        EventInstance.release();//Удаляет этот контейнер
    }
}

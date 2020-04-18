using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_UI_Button : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string UIButton; // Переменная для ивента

    FMOD.Studio.EventInstance EventInstance; // Переменная для инстанаса

    public void PlayUiButton()
    {
        EventInstance = FMODUnity.RuntimeManager.CreateInstance(UIButton);//создаёт  контейнер для семпла
        EventInstance.start();//Проигрывает этот контейнер
        EventInstance.release();//Удаляет этот контейнер
    }
}

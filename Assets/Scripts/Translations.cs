using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Translations
{

    private static Dictionary<string, string> Spanish = new Dictionary<string, string>() {
        { "2", "En la oficina, suena tu teléfono. De la escuela te avisan que nadie fue a buscar a tu hijo." },
        { "2A", "Buscas a tu hijo" },
    };


    public static string Get(string textId)
    {
        return Spanish[textId];
    }
}

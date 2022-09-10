using System.Collections.Generic;

public static class Translations
{

    private static Dictionary<string, string> Spanish = new Dictionary<string, string>() {
        
        { "1",  "En la oficina, suena tu tel�fono. De la escuela te avisan que nadie fue a buscar a tu hijo." },
        { "1A", "[Buscas a tu hijo]" },
        { "1B", "[Seguis trabajando]" },
        { "2" , "Tu ex-marido se llev� a tu hijo por primera vez en mucho tiempo. Finalmente tenes una noche libre para salir."},
        { "2A", "[Cenas con tu famila]"},
        { "2B", "[Salis con amigas]"},
        { "3","El grupo de mensajes de la escuela no deja de sonar. De nuevo te piden que colabores con el acto escolar."},
        { "3A","[Te negas]"},
        { "3B","[Aceptas ayuda]"},
        { "4","Te asignan tu primer cliente: una empresa de ropa para maternar! Tu compa�ero cishetero te quiere explicar c�mo tratar el tema para llegar a m�s madres."},
        { "4A","[Te quedas callada]"},
        { "4B","[Haces escuchar tu voz]"},
        { "5","Est�s presentando una idea en el trabajo, cuando un compa�ero te interrumpe y minimiza tu idea. Cuenta exactamente lo mismo, pero como si fuera su idea."},
        { "5A","[No decis nada]"},
        { "5B","[Lo interrumpis]"},
        { "6","Llegas a tu casa despu�s de un largo d�a de trabajo, pero la rutina no se termina. La casa sigue desordenada y tu hijo no deja de pedir ayuda con su tarea."},
        { "6A","[Limpias la casa]"},
        { "6B","[Lo ayudas con la tarea]"},
        { "7","En el subte, de camino a tu casa, un hombre se abre de pierna empuj�ndote e invadiendo tu espacio."},
        { "7A","[Te arrinconas]"},
        { "7B","[Lo empujas]"},
        { "8","Te invitaron a un evento del trabajo, pero no tenes ropa formal para asistir. Necesitas comprarte, pero est�s cuidando a tu hijo que ya se fastidi� con la idea de salir."},
        { "8A", "[Vas a un local de barrio]"},
        { "8B", "[Vas a un local inclusivo]"}
        
    };


    public static string Get(string textId)
    {
        return Spanish[textId];
    }
}

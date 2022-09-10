using System.Collections.Generic;

public static class Translations
{

    private static Dictionary<string, string> Spanish = new Dictionary<string, string>() {
        
        { "2", "En la oficina, suena tu teléfono. De la escuela te avisan que nadie fue a buscar a tu hijo." },
        { "2A", "[Buscas a tu hijo]" },
        { "2B", "[Seguis trabajando]" },
        {"1","Tu ex-marido se llevó a tu hijo por primera vez en mucho tiempo. Finalmente tenes una noche libre para salir."},
        {"1A","[Cenas con tu famila]"},
        {"1B","[Salis con amigas]"},
        {"1A","[Salis con amigas]"},
        
    };


    public static string Get(string textId)
    {
        return Spanish[textId];
    }
}

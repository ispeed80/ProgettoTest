using System;

namespace ProgettoTest.ConfigPredefiniti
{
    // OGNI sezione del file .ini diventa una classe statica
    // Formato: Predefiniti_[NomeSezione]

    // Corrisponde alla sezione [Ricerca] nel file .ini
    public static class Predefiniti_Ricerca
    {
        public static string RicercaPredefinita { get; set; } = "";
        public static string TipoRicercaPredefinito { get; set; } = "Descrizione Esame";
    }

    // Corrisponde alla sezione [Database] nel file .ini
    public static class Predefiniti_Database
    {
        // Valori di default
        public static string Server { get; set; } = "";
        public static string DatabaseName { get; set; } = "";
        public static bool IntegratedSecurity { get; set; } = true;
        public static string UserId { get; set; } = "";
        public static string Password { get; set; } = "";
        public static int TimeoutConnessione { get; set; } = 15;
    }
}
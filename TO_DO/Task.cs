using System;
using System.Collections.Generic;
using System.IO;

class Task
{
    public int Id { get; set; }
    public string Tytul { get; set; }
    public string Opis { get; set; }
    public string DataStart { get; set; }
    public string DataKoniec { get; set; }
    public int Priorytet { get; set; }
    public string Status { get; set; }
    public Task(int id, string tytul, string opis, string datastart, string datakoniec, int priorytet, string status)
    {
        Id = id;
        Tytul = tytul;
        Opis = opis;
        DataStart = datastart;
        DataKoniec = datakoniec;
        Priorytet = priorytet;
        Status = status;
    }
}
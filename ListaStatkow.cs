using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatkiPowietrzne
{
    // Dzięki liście obiektów typu statek można się dostać do poszczególnych utworzonych statków. Statek dodaje
    // się do listy automatycznie po dodaniu na radar
    public class ListaStatkow
    {
        private List<Statek> lista = new List<Statek>();
        // Dodawanie statku do listy
        public void DodajDoListy(Statek statek)
        {
            lista.Add(statek);
        }
        // pobranie listy
        public List<Statek> GetLista()
        {
            return lista;
        }
        // Usuniecie statku z listy
        public void SetLista(int indeks)
        {
            lista.RemoveAt(indeks);
        }
        // pobranie konkretnego statku z listy
        public Statek GetStatek(int indeks)
        {
            return lista.ElementAt(indeks);
        }
        

    }
}
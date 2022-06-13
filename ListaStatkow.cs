using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatkiPowietrzne
{
    public class ListaStatkow
    {
       private List<Statek> lista = new();
        public void DodajDoListy(Statek statek)
        {
            lista.Add(statek);
        }
        public List<Statek> GetLista()
        {
            return lista;
        }
        public void SetLista(int indeks)
        {
            lista.RemoveAt(indeks);
        }
        public Statek GetStatek(int indeks)
        {
            return lista[indeks];
        }
    }
}

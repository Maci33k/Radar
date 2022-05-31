using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatkiPowietrzne
{
    public class Trasa
    {
        private ArrayList listaLinii = new ArrayList();

        public void DodajLinie(Linia l)
        {
            listaLinii.Add(l);
        }
        public void UsunLinie(int indeks)
        {
            listaLinii.Remove(indeks);
        }
        public Linia AktualnaLinia()
        {
            return listaLinii[listaLinii.Count - 1];
        }
        // Metoda Trasa tu powinna być
        // Metoda KoniecTrasy tu powinna tez byc

    }
}

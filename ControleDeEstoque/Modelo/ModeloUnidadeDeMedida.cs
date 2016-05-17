using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public class ModeloUnidadeDeMedida
    {
        public ModeloUnidadeDeMedida()//Construtor
        {
            this.UmedCod = 0;
            this.UmedNome = "";
        }//Fim
        public ModeloUnidadeDeMedida(int cod, String nome)//Construtor
        {
            this.UmedCod = cod;
            this.UmedNome = nome;
        }//Fim

        private int umed_cod;
        public int UmedCod
        {
            get
            {
                return this.umed_cod;//Retorna o Valor
            }
            set
            {
                this.umed_cod = value;//Recebe o Valor
            }
        }
        private String umed_nome;
        public String UmedNome
        {
            get
            {
                return this.umed_nome;
            }
            set
            {
                this.umed_nome = value;
            }
        }
    }
}

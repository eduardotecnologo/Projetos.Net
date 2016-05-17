using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmModeloDeFormularioDeCadastro : Form
    {
        public String operacao;
        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alterarBotoes(int op)
        {
            //op = Operações que serão feitas com os Botões
            //1  = Preparar os botões para Inserir e Localizar
            //2  = Preparar para Inserir/Alterar um Registro
            //3  = Preparar a tela para Inserir ou Alterar

            pnDados.Enabled = false;
            btnIserir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLocalizar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            if (op == 1)
            {
                btnIserir.Enabled = true;
                btnLocalizar.Enabled = true;
            }
            if (op == 2)
            {
                pnDados.Enabled = true;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            if (op == 3)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
          
        private void frmModeloDeFormularioDeCadastro_Load_1(object sender, EventArgs e)
        {
            this.alterarBotoes(1);
        }

        private void frmModeloDeFormularioDeCadastro_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
 }

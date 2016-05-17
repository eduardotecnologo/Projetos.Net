using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace GUI
{
    public partial class frmConsultaProdutos : Form
    {
        public int codigo = 0;
        public frmConsultaProdutos()
        {
            InitializeComponent();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }

        private void frmConsultaProdutos_Load(object sender, EventArgs e)
        {
            btnLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 45;
            dgvDados.Columns[1].HeaderText = "Modelo";
            dgvDados.Columns[1].Width = 100;
            dgvDados.Columns[2].HeaderText = "Descrição";
            dgvDados.Columns[2].Width = 400;
            dgvDados.Columns[3].HeaderText = "Foto";
            dgvDados.Columns[3].Width = 200;
            dgvDados.Columns[4].HeaderText = "Valor Pago";
            dgvDados.Columns[4].Width = 90;
            dgvDados.Columns[5].HeaderText = "Valor de Venda";
            dgvDados.Columns[5].Width = 90;
            dgvDados.Columns[6].HeaderText = "Quantidade";
            dgvDados.Columns[6].Width = 90;
            dgvDados.Columns[7].HeaderText = "Unidade de Medida";
            dgvDados.Columns[7].Width = 90;
            dgvDados.Columns[8].HeaderText = "Categoria";
            dgvDados.Columns[8].Width = 60;
            dgvDados.Columns[9].HeaderText = "SubCategoria";
            dgvDados.Columns[9].Width = 60;
            dgvDados.Columns[10].HeaderText = "Produto";
            dgvDados.Columns[10].Width = 60;
            dgvDados.Columns[11].HeaderText = "Tipo";
            dgvDados.Columns[11].Width = 60;
            dgvDados.Columns[12].HeaderText = "Marca";
            dgvDados.Columns[12].Width = 60;

            //Oculta Colunas
            dgvDados.Columns["umed_nome"].Visible = false;
            dgvDados.Columns["cat_cod"].Visible = false;
            dgvDados.Columns["scat_cod"].Visible = false;
            dgvDados.Columns["umed_cod"].Visible = false;
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}

using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo;
using GUI;
using System.IO;

namespace GUI
{
    public partial class frmCadastroProduto : GUI.frmModeloDeFormularioDeCadastro
    {
        public string foto = "";

        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void btnIserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alterarBotoes(2);
        }
        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();
            this.foto = "";
            pbFoto.Image = null;
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            this.alterarBotoes(1);
            //ComboBox da Categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbCategoria.DataSource = bll.Localizar("");
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";
            try
            {
                //ComboBox da Subcategoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                MessageBox.Show("Cadastre uma Categoria");
            }
            //ComboBox da Unidade de Medidas
            BLLUnidadeDeMedida ubll = new BLLUnidadeDeMedida(cx);
            cbUnd.DataSource = ubll.Localizar("");
            cbUnd.DisplayMember = "umed_nome";
            cbUnd.ValueMember = "umed_cod";
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(".") == false)
            {
                txtValorVenda.Text += ".00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(".") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                txtValorVenda.Text = "0.00";
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(".") == false)
            {
                txtValorPago.Text += ".00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(".") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0.00";
            }
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtQtde.Text.Contains("."))
                {
                    e.KeyChar = '.';
                }
                else e.Handled = true;
            }
        }

        private void txtQtde_Leave(object sender, EventArgs e)
        {
            if (txtQtde.Text.Contains(".") == false)
            {
                txtQtde.Text += ".00";
            }
            else
            {
                if (txtQtde.Text.IndexOf(".") == txtQtde.Text.Length - 1)
                {
                    txtQtde.Text += "00";
                }
            }
            try
            {
                Double d = Convert.ToDouble(txtQtde.Text);
            }
            catch
            {
                txtQtde.Text = "0.00";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.operacao = "alterar";
            this.alterarBotoes(2);
        }
        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja Excluir o Registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    BLLProduto bll = new BLLProduto(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    this.LimpaTela();
                    this.alterarBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo usado em outro local.");
                this.alterarBotoes(3);
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox da Categoria
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            try
            {
                cbSubCategoria.Text = "";
                //ComboBox da Subcategoria
                BLLSubCategoria sbll = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = sbll.LocalizarPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma Categoria");
            }
        }

        private void btnCarregaImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (!string.IsNullOrEmpty(od.FileName))
            {
                this.foto = od.FileName;
                pbFoto.Load(this.foto);
            }
        }

        private void btnRemoveImg_Click(object sender, EventArgs e)
        {
            this.foto = "";
            pbFoto.Image = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try { 
            //Leitura dos Dados
            ModeloProduto modelo = new ModeloProduto();
            modelo.ProNome = txtNome.Text;
            modelo.ProDescricao = txtDescricao.Text;
            modelo.ProValorPago = Convert.ToDouble(txtValorPago.Text);
            modelo.ProValorVenda = Convert.ToDouble(txtValorVenda.Text);
            modelo.ProQtde = Convert.ToDouble(txtQtde.Text);
            modelo.UmedCod = Convert.ToInt32(cbUnd.SelectedValue);
            modelo.CatCod = Convert.ToInt32(cbCategoria.SelectedValue);
            modelo.ScatCod = Convert.ToInt32(cbSubCategoria.SelectedValue);
            modelo.CarregaImagem(this.foto);
            //Obj para gravar os dados no banco
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            if (this.operacao == "inserir")
            {
                bll.Incluir(modelo);
                MessageBox.Show("Cadastro Efetuado: Código" + modelo.ProCod.ToString());
            }
            else
            {
                modelo.ProCod = Convert.ToInt32(txtCodigo.Text);
                bll.Alterar(modelo);
                MessageBox.Show("Cadastro Alterado");
            }
            this.LimpaTela();
            this.alterarBotoes(1);
        }
        catch (Exception erro)
            {
            MessageBox.Show(erro.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.alterarBotoes(1);
            this.LimpaTela();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaProdutos f = new frmConsultaProdutos();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);
                ModeloProduto modelo = bll.CarregaModeloProduto(f.codigo);
                txtCodigo.Text = modelo.CatCod.ToString();
                //Adiciona os Dados na Tela
                txtNome.Text = modelo.ProCod.ToString();
                txtDescricao.Text = modelo.ProDescricao.ToString();
                txtQtde.Text = modelo.ProQtde.ToString();
                txtValorPago.Text = modelo.ProValorPago.ToString();
                txtValorVenda.Text = modelo.ProValorVenda.ToString();
                cbCategoria.SelectedValue = modelo.CatCod;
                cbSubCategoria.SelectedValue = modelo.ScatCod;
                cbUnd.SelectedValue = modelo.UmedCod;
                //Adiciona a Foto
                try
                {
                    MemoryStream ms = new MemoryStream(modelo.ProFoto);
                    pbFoto.Image = Image.FromStream(ms);
                }
                catch //Caso não tenha foto selecionada
                {

                }
                alterarBotoes(3);
            }
            else
            {
                this.LimpaTela();
                this.alterarBotoes(1);
            }
            f.Dispose();
        }
    }
}
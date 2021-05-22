using GeradorEtiquetasNew;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorEtiquetas
{
    public partial class GeradorEtiquetaForm : Form
    {
        private const string chave = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";

        public GeradorEtiquetaForm()
        {
            InitializeComponent();
            Stimulsoft.Base.StiLicense.Key = chave;
        }

        private void btnGerarEtiqueta_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            var report = new StiReport();

            using (Dados dstDados = new Dados())
            {
                Dados.GeralRow geralRow = dstDados.Geral.NewGeralRow();

                geralRow.Nome = txtNome.Text;
                geralRow.CEP = Convert.ToUInt64(txtCEP.Text).ToString(@"00000\-000");
                geralRow.Rua = txtRua.Text;
                geralRow.Numero = int.Parse(txtNumero.Text);
                geralRow.Bairro = txtBairro.Text;
                geralRow.Cidade = txtCidade.Text;
                geralRow.Estado = txtEstado.Text;

                dstDados.Geral.AddGeralRow(geralRow);

                for (Int32 i = 0; i < dataGridItens.Rows.Count - 1; i++)
                {
                    Dados.ItemRow itemRow = dstDados.Item.NewItemRow();

                    itemRow.Produto = dataGridItens.Rows[i].Cells[0].Value.ToString();
                    itemRow.Quantidade = int.Parse(dataGridItens.Rows[i].Cells[1].Value.ToString());
                    itemRow.Valor = decimal.Parse(dataGridItens.Rows[i].Cells[2].Value.ToString());

                    dstDados.Item.AddItemRow(itemRow);
                }

                report.RegData(dstDados);

                report.Load("Report.mrt");

                report.Show();

                //report.Render();

                //report.ExportDocument(StiExportFormat.Pdf, $"Etiqueta_{ txtNome.Text.Replace(" ", string.Empty) }");

                //report.Design();

            }
        }
    }
}
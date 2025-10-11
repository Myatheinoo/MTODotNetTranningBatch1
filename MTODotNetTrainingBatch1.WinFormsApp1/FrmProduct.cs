using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MTODotNetTrainingBatch1.WinFormsApp1.Query;

namespace MTODotNetTrainingBatch1.WinFormsApp1
{
    public partial class FrmProduct : Form
    {
        private readonly SqlService _sqlService;
        public FrmProduct()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _sqlService = new SqlService();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            DataTable dt = _sqlService.Query(ProductQuery.GetAllProduct);
            dgvData.DataSource = dt;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string code = textBox2.Text.Trim();
            decimal price = Convert.ToDecimal(textBox3.Text.Trim());
            int qunatity = Convert.ToInt32(textBox4.Text.Trim());

            int result = _sqlService.Exectue(ProductQuery.InsertProduct,
                new SqlParameter("@Name", name),
                new SqlParameter("@Code", code),
                new SqlParameter("@Price", price),
                new SqlParameter("@Quantity", qunatity),
                new SqlParameter("@CreatedDate", DateTime.UtcNow),
                new SqlParameter("@CurrentUser", AppSetting.CurrentUserId)
                );

            string message = result > 0 ? "Create successful." : "Fail to create.";

            MessageBox.Show(message,
                "Inventory Management System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            ClearData();
            BindData();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void ClearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}

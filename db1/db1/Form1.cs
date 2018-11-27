using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db1
{
    public partial class Form1 : Form
    {
        public SQLControl _sql = new SQLControl();

        public void fLoadGrid(String sQuery)
        {

            _sql.fNew("data source=HSCOMPUTER\\MSSQLSERVER2017;initial catalog=LANGUAGE4;integrated security=True;persist security info=True");
            if (sQuery == null)
            {
                _sql.fExecQuery("SELECT * FROM dbo.tEnglish;");
            }
            else
            {
                _sql.fExecQuery(sQuery);
            }

            if (_sql.fHasException(true))
            {
                goto lineend;
            }
        
            grid1.DataSource = _sql._ds;
            lineend:;
        }

        public void fFindItem()
        {
            _sql.fAddParam("@item", "%" + txtSearch.Text + "%");
            fLoadGrid("SELECT * FROM tEnglish WHERE sSeen LIKE @item;");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            fLoadGrid(null);
           }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dset1xsd.tMalay' table. You can move, or remove it, as needed.
            this.tMalayTableAdapter.Fill(this.dset1xsd.tMalay);
            // TODO: This line of code loads data into the 'dset1xsd.tKorean' table. You can move, or remove it, as needed.
            this.tKoreanTableAdapter.Fill(this.dset1xsd.tKorean);
            // TODO: This line of code loads data into the 'dset1xsd.tIndian' table. You can move, or remove it, as needed.
            this.tIndianTableAdapter.Fill(this.dset1xsd.tIndian);
            // TODO: This line of code loads data into the 'dset1xsd.tEnglish' table. You can move, or remove it, as needed.
            this.tEnglishTableAdapter.Fill(this.dset1xsd.tEnglish);
        }

        private void grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            fFindItem();
        }
    }
}

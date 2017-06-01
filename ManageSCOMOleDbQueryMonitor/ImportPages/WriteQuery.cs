using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class WriteQuery : UserControl, IWizardPage
    {
        private string QureyTamplate { get; set; }
        public WriteQuery()
        {
            InitializeComponent();
        }

        public WriteQuery(SharedData data) : this()
        {
            this.data = data;
        }

        ConnectionState _ConState;
        private SharedData data;

        public UserControl Content
        {
            get
            {
                return this;
            }
        }

        public bool IsBusy
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool PageValid
        {
            get
            {
                if (Validation())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        private bool Validation()
        {
            bool val = true;
            val = !string.IsNullOrEmpty(txtDatabase.Text) ? true : false;
            val = !string.IsNullOrEmpty(txtQuery.Text) ? true : false;
            if (val)
            {
                val = txtQuery.Text.IsValidSql() ? true : false;
            }
            return val;
        }

        public string ValidationMessage
        {
            get
            {
                return "Databsae name Or query emtpy Or query is invalid, check again";
            }
        }

        private void txtConSql_LinkClicked(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(txtConSql.Text))
            {
                try
                {

                    con.Open();
                    _ConState = con.State;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                    return;
                }

            }
            MessageBox.Show(Enum.GetName(typeof(ConnectionState), _ConState));
        }

        void IWizardPage.Load()
        {
            // throw new NotImplementedException();
            txtConSql.Text = "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI";

            SCOMSDKWrapper s = new SCOMSDKWrapper(data);

        
            txtConSql.Text = string.Format(txtConSql.Text, data.DBEngine.Path + "\\" + data.DBEngine.DisplayName, "{0}");
            QureyTamplate = txtConSql.Text;
            if (!string.IsNullOrEmpty(txtDatabase.Text))
            {
                txtConSql.Text = string.Format(txtConSql.Text, txtDatabase.Text);
            }

        }

        public void Save()
        {
            data.QueryDataInfo = new QueryData();
            data.QueryDataInfo.Database = txtDatabase.Text;
            data.QueryDataInfo.ConnectionString = txtConSql.Text;

            data.QueryDataInfo.Query = txtQuery.Text;
        }

        public void Cancel()
        {
            //  txtQuery.Text = string.Empty;
            //txtDatabase.Text = string.Empty;
            txtConSql.Text = "Provider=SQLOLEDB;Data Source={0};Initial Catalog={1};Integrated Security=SSPI";
            txtConSql.Text = string.Format(txtConSql.Text, data.DBEngine.Path + "\\" + data.DBEngine.DisplayName, "{0}");
            if (!string.IsNullOrEmpty(txtDatabase.Text))
            {
                txtConSql.Text = string.Format(txtConSql.Text, txtDatabase.Text);
            }
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            KryptonTextBox txt = sender as KryptonTextBox;
            txtConSql.Text = string.Format(QureyTamplate, txt.Text);
        }

        private void btnTestQuery_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(txtConSql.Text))
            {
                using (OleDbCommand cmd = new OleDbCommand(txtQuery.Text, con))
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(dt);

                        if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
                        {
                            double value;
                            if (double.TryParse(dt.Rows[0][0].ToString(), out value))
                            {
                                MessageBox.Show("return numeric value successfully test, result value " + value);
                            }
                            else
                            {
                                MessageBox.Show("return not numeric value rewrite query, result value " + dt.Rows[0][0].ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("return more then one row or column");
                        }
                    }
                    catch (Exception EX)
                    {

                        MessageBox.Show("Error: " + EX.Message);
                    }

                }
            }
        }


    }
}

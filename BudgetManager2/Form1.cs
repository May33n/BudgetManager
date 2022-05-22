using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetManager2
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        private readonly BudgetManagerEntities budgetManagerEntities;

        public Form1()
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
        }

        private void OpenNewForm(Form newForm, object btnNew)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(newForm);
            this.pnlContainer.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenNewForm(new FormNew(), sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var entries = budgetManagerEntities.BudgetManagers.Select(q => new
            {
                NAME = q.Name,
                AMOUNT = q.Amount,
                NOTES = q.Notes,
                DATE = q.Date
            }).ToList();

            dgvBudgetEntries.DataSource = entries;
        }
    }
}

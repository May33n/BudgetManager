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
    public partial class FormNew : Form
    {
        private readonly BudgetManagerEntities budgetManagerEntities;
        public FormNew()
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var budgetManager = new BudgetManager();

            string name = txtBoxName.Text;
            string notes = txtBoxNotes.Text;
            var date = dt.Value;
            int amount = int.Parse(txtBoxAmount.Text);

            budgetManager.Name = name;
            budgetManager.Notes = notes;
            budgetManager.Date = date;
            budgetManager.Amount = amount;

            budgetManagerEntities.BudgetManagers.Add(budgetManager);
            budgetManagerEntities.SaveChanges();

            MessageBox.Show("OK");
        }
    }
}

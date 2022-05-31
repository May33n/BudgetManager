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
        private readonly BudgetManagerEntities budgetManagerEntities;

        public Form1()
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
        }

        private void OpenNewForm(Form newForm, object btnNew)
        {
            newForm.BringToFront();
            newForm.Parent = Parent;  //??
            newForm.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenNewForm(new FormNew(), sender);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //get id of selected row
            var id = (int)dgvBudgetEntries.SelectedRows[0].Cells["id"].Value;

            //query database for record
            var entry = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);

            //launch FormNew window with data
            OpenNewForm(new FormNew(entry), sender);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = (int)dgvBudgetEntries.SelectedRows[0].Cells["id"].Value;
            var entry = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);

            //delete entry
            budgetManagerEntities.BudgetManagers.Remove(entry);
            budgetManagerEntities.SaveChanges();
            dgvBudgetEntries.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var entries = budgetManagerEntities.BudgetManagers
               .Select(q => new
               {
                   NAME = q.Name,
                   AMOUNT = q.Amount,
                   NOTES = q.Notes,
                   DATE = q.Date,
                   Id = q.id

               })
               .ToList();

            dgvBudgetEntries.DataSource = entries;
            dgvBudgetEntries.Columns[4].Visible = false;
        }
    }
}

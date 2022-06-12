using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Drag form 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void OpenNewForm(Form newForm, object btnNew)
        {
            newForm.BringToFront();
            newForm.Parent = Parent; 
            newForm.Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenNewForm(new FormNew(this), sender);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)dgvBudgetEntries.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var entry = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);

                //launch FormNew window with data
                OpenNewForm(new FormNew(entry, this), sender);
            }
            catch (Exception)
            {
                MessageBox.Show("Prosím vyber zápis, který chceš změnit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvBudgetEntries.SelectedRows[0].Cells["id"].Value;
                var entry = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);

                //delete entry
                budgetManagerEntities.BudgetManagers.Remove(entry);
                budgetManagerEntities.SaveChanges();
                dgvBudgetEntries.Refresh();
                PopulateGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Prosím vyber zápis, který chceš smazat");
            }
        }

        public void PopulateGrid()
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }   
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

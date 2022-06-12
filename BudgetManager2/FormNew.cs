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
    public partial class FormNew : Form
    {
        private readonly BudgetManagerEntities budgetManagerEntities;
        private bool isEditMode;
        private Form1 _form1;

        public FormNew(Form1 form1 = null)
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Add new entry";
            isEditMode = false;
            this._form1 = form1;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public FormNew(BudgetManager entryToEdit, Form1 form1 = null)
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Edit entry";
            this._form1 = form1;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if (entryToEdit == null)
            {
                MessageBox.Show("Prosím vyber zápis, který chceš změnit.");
                Close();
            }
            else
            {
                PopulateFields(entryToEdit);
                isEditMode = true;
            }
        }

        //Drag form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void PopulateFields(BudgetManager entryToEdit)
        {
            lblId.Text = entryToEdit.id.ToString();
            txtBoxName.Text = entryToEdit.Name;
            txtBoxAmount.Text = entryToEdit.Amount.ToString();
            txtBoxNotes.Text = entryToEdit.Notes;
            dt.Value = (DateTime)entryToEdit.Date;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditMode)
                {
                    if (string.IsNullOrWhiteSpace(txtBoxAmount.Text))
                    {
                        MessageBox.Show("Prosím zadej cenu");
                    }
                    else
                    {
                        var id = int.Parse(lblId.Text);
                        var entryToEdit = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);
                        entryToEdit.Name = txtBoxName.Text;
                        entryToEdit.Amount = int.Parse(txtBoxAmount.Text);
                        entryToEdit.Notes = txtBoxNotes.Text;
                        entryToEdit.Date = dt.Value;
                        budgetManagerEntities.SaveChanges();
                        MessageBox.Show("OK");
                        Close();
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtBoxAmount.Text))
                    {
                        MessageBox.Show("Prosím zadej cenu");
                    }
                    else
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
                        MessageBox.Show("OK");
                        Close();
                    }
                }
            
                budgetManagerEntities.SaveChanges();
                _form1.PopulateGrid();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Prosím vyber zápis");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNew_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

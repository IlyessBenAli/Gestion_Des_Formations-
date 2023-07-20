using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            // Ajouter l'événement Validating pour le champ nomTextEdit
            textEdit1.Validating += textEdit1_Validating;

        }
        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text.Trim()) || !textEdit1.Text.Contains("@"))
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez entrer une adresse email valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Annuler la validation
                e.Cancel = true;
            }
        }


        private void imageEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
           

          
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string email = textEdit1.Text;
            string password = textEdit2.Text;

            // Query the database to find a Responsable entity with a matching email and password
            using (var ctx = new Data.FormationEntities())
            {
                var responsable = ctx.Responsable.FirstOrDefault(r => r.email == email && r.password == password);

                if (responsable != null)
                {
                    // Log the user in
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Session formateur = new Session();
                    formateur.Show();
                    this.Hide();
                    // Do something else, such as navigate to a different form or show a main menu
                }
                else
                {
                    // Display an error message
                    MessageBox.Show("Invalid email or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }
    }
}

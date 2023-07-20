 using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class Formateur : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Formateur()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            Participant_1 participant_1 = new Participant_1();
            participant_1.Show();
            this.Hide();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            Reunion_1 reunion_1 = new Reunion_1();
            reunion_1.Show();
            this.Hide();
        }

        private void nomTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void prenomLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void nomLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            formateurBindingSource.AllowNew = true;
            formateurBindingSource.AddNew();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            try
            {
                using (var ctx = new Data.FormationEntities())
                {
                    ctx.Formateur.Add((Data.Formateur)formateurBindingSource.Current);
                    ctx.SaveChanges();
                    MessageBox.Show("Formateur ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formateurBindingSource.DataSource = ctx.Formateur.ToList();
                    formateurBindingSource.ResetBindings(false);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationResult.ValidationErrors)
                    {
                        MessageBox.Show($"Erreur de validation pour la propriété '{validationError.PropertyName}': {validationError.ErrorMessage}");
                    }
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
             
    
        
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();
            Data.Formateur formateur = ctx.Formateur.Find(((Data.Formateur)formateurBindingSource.Current).idformateur);
            ctx.Formateur.Remove(formateur);

            ctx.SaveChanges();
            MessageBox.Show("formateur Delteed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            formateurBindingSource.DataSource = ctx.Formateur.ToList();
            formateurBindingSource.ResetBindings(false);
        }

        private void Formateur_Load(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();

            formateurBindingSource.DataSource = ctx.Formateur.ToList();
            formateurBindingSource.ResetBindings(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void specialiteLabel_Click(object sender, EventArgs e)
        {

        }

        private void specialiteTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataNavigator1_Click(object sender, EventArgs e)
        {

        }

        private void formateurBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Data.FormationEntities c = new Data.FormationEntities();
            var foorm = (Data.Formateur)formateurBindingSource.Current;

            // Create a new instance of Formateur
            var modifiedFoorm = new Data.Formateur
            {
                idformateur = foorm.idformateur,
                nom = foorm.nom,
                prenom = foorm.prenom,
                email=foorm.email,
                specialite=foorm.specialite
                // Copy other properties that you want to modify
            };

            // Update the state of the new instance to Modified
            c.Entry(modifiedFoorm).State = EntityState.Modified;

            // Save the changes to the database
            c.SaveChanges();

            MessageBox.Show("Formateur Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the data in the binding source
            formateurBindingSource.DataSource = c.Formateur.ToList();
            formateurBindingSource.ResetBindings(false);








        }
    }
}

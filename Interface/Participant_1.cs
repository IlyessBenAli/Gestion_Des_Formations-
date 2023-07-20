using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace Interface
{
    public partial class Participant_1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Participant_1()
        {
            InitializeComponent();
            nomTextEdit.Validating += nomTextEdit_Validating;
            prenomTextEdit.Validating += prenomTextEdit_Validating;
            emailTextEdit.Validating += emailTextEdit_Validating;

        }

        private void nomTextEdit_Validating(object sender, CancelEventArgs e)
        {
            // Vérifier si le champ nomTextEdit est vide ou sa longueur dépasse 50 caractères
            if (string.IsNullOrEmpty(nomTextEdit.Text.Trim()) || nomTextEdit.Text.Length > 50)
            {
                // Afficher un message d'erreur
                MessageBox.Show("Le nom ne doit pas être vide et ne doit pas dépasser 50 caractères.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Annuler la validation
                e.Cancel = true;
            }
            else
            {
                // Effacer le message d'erreur
                MessageBox.Show("Validation réussie!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void prenomTextEdit_Validating(object sender, CancelEventArgs e)
        {
            // Vérifier si le champ prenomTextEdit est vide ou sa longueur dépasse 50 caractères
            if (string.IsNullOrEmpty(prenomTextEdit.Text.Trim()) || prenomTextEdit.Text.Length > 50)
            {
                // Afficher un message d'erreur
                MessageBox.Show("Le prénom ne doit pas être vide et ne doit pas dépasser 50 caractères.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Annuler la validation
                e.Cancel = true;
            }
        }
        private void emailTextEdit_Validating(object sender, CancelEventArgs e)
        {
            // Vérifier si l'adresse email est vide ou si elle ne contient pas de '@'
            if (string.IsNullOrEmpty(emailTextEdit.Text.Trim()) || !emailTextEdit.Text.Contains("@"))
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez entrer une adresse email valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Annuler la validation
                e.Cancel = true;
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
          

        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            Formateur formateur = new Formateur ();
            formateur.Show();
            this.Hide();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();

            participantBindingSource.DataSource = ctx.Participant.ToList(); ;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            


                Data.FormationEntities ctx = new Data.FormationEntities();
                ctx.Participant.Add((Data.Participant)participantBindingSource.Current);
                ctx.SaveChanges();
                MessageBox.Show("Participant added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            // Vider les champs
            nomTextEdit.Text = "";
            prenomTextEdit.Text = "";
            emailTextEdit.Text = "";
            participantBindingSource.DataSource = ctx.Participant.ToList();
            participantBindingSource.ResetBindings(false);

        }









            private void simpleButton4_Click(object sender, EventArgs e)
        {
            participantBindingSource.AllowNew = true;
            participantBindingSource.AddNew();

        }

        private void nomTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();
            var participant = (Data.Participant)participantBindingSource.Current;
            ctx.Entry(participant).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            ctx.Entry(participant).State = System.Data.Entity.EntityState.Detached; // Detach the entity
            MessageBox.Show("Participant Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            participantBindingSource.DataSource = ctx.Participant.ToList();
            participantBindingSource.ResetBindings(false);

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();
            Data. Participant participant = ctx.Participant.Find(((Data.Participant)participantBindingSource.Current).idparticipant);
            ctx.Participant.Remove(participant);

            ctx.SaveChanges();
            MessageBox.Show("Participant Delteed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            participantBindingSource.DataSource = ctx.Participant.ToList();
            participantBindingSource.ResetBindings(false);
        }

        private void Participant_1_Load_1(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();


            participantBindingSource.DataSource = ctx.Participant.ToList();
            participantBindingSource.ResetBindings(false);
        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void nomLabel_Click(object sender, EventArgs e)
        {

        }

        private void nomTextEdit_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prenomLabel_Click(object sender, EventArgs e)
        {

        }

        private void participantBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nomTextEdit_EditValueChanged_2(object sender, EventArgs e)
        {

        }

        private void prenomTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void nomLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void prenomLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void emailTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            Session Session = new Session();
            Session.Show();
            this.Hide();
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            Reunion_1 reunion_1 = new Reunion_1();
            reunion_1.Show();
            this.Hide();
        }
    }
}

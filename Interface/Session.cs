using Data;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting.BarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QRCoder;


namespace Interface
{
    public partial class Session : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Session()
        {
            InitializeComponent();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void datefinsessionLabel_Click(object sender, EventArgs e)
        {

        }

        private void titresessionTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            sessionFormationBindingSource.AllowNew = true;
            sessionFormationBindingSource.AddNew();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            var session1=  new Data.SessionFormation() ;
            using (var ctx = new Data.FormationEntities())
            {
                var session = sessionFormationBindingSource.Current as Data.SessionFormation;
                session1 = session;
                if (session != null)
                {
                    // Add the reunion entity to the context



                    // Add the related formateur entities to the context
                    foreach (DataGridViewRow row in formateurDataGridView.SelectedRows)
                    {
                        var formateur = row.DataBoundItem as Data.Formateur;
                        if (formateur != null)
                        {
                            // Load the formateur entity from the context
                            formateur = ctx.Formateur.Find(formateur.idformateur);
                            session.idformateur = formateur.idformateur;
                            ctx.SessionFormation.Add(session);


                            //reunion.Reunionform.Add(new Reunionform { Reunion = reunion, Formateur = formateur });
                        }
                    }
                    foreach (DataGridViewRow row in participantDataGridView.SelectedRows)
                    {
                        var participant = row.DataBoundItem as Data.Participant;
                        if (participant != null)
                        {
                            // Load the formateur entity from the context
                            participant = ctx.Participant.Find(participant.idparticipant);

                            Data.PartSession PartSession = new Data.PartSession(participant.idparticipant, session.idsession);


                            // Add the Reunionform entity to the context
                            ctx.PartSession.Add(PartSession); ;
                            //reunion.Reunionform.Add(new Reunionform { Reunion = reunion, Formateur = formateur });
                        }
                    }


                }

                // Save changes to the database
                try
                {
                    // Save changes to the database
                    ctx.SaveChanges();
                    // Refresh the binding source with the updated data from the database
                    sessionFormationBindingSource.DataSource = ctx.SessionFormation.ToList();
                    sessionFormationBindingSource.ResetBindings(false);

                    // Show a success message to the user
                    MessageBox.Show("Session added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbEntityValidationException ex)
                {
                    Debug.WriteLine(ex);
                    foreach (var error in ex.EntityValidationErrors)
                    {
                        Console.WriteLine("Validation errors for entity of type {0}:",
                            error.Entry.Entity.GetType().Name);
                        foreach (var validationError in error.ValidationErrors)
                        {
                            Console.WriteLine("- Property: {0}, Error: {1}",
                                validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            // Créer le client SMTP
            var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential("lassbnali@gmail.com", "hvhcfhokhsrbcivk"),
                EnableSsl = true
            };

            // Parcourir tous les participants sélectionnés et les ajouter à la liste de destinataires
            var destinataires = new List<string>();
            foreach (DataGridViewRow row in participantDataGridView.SelectedRows)
            {
                var participant = row.DataBoundItem as Data.Participant;
                if (participant != null)
                {
                    destinataires.Add(participant.email);
                }
            }
            var ctx1 = new Data.FormationEntities();
            // Générer le contenu de l'e-mail
              session1 = ctx1.SessionFormation.Find(session1.idsession);
            string sujet = $"Nouvelle session : {session1.titresession}";
            string corps = $"La nouvelle session '{session1.titresession}' commencera le {session1.datedebutsession.ToShortDateString()} et se terminera le {session1.datefinsession.ToShortDateString()}.";

            // Créer le message et l'envoyer
            var message = new System.Net.Mail.MailMessage("lassbnali@gmail.com", string.Join(",", destinataires), sujet, corps);
            client.Send(message);
            MessageBox.Show("Mails sends successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            session1 = ctx1.SessionFormation.Find(session1.idsession);
            string texte = $"Session : {session1.titresession}, Date : {session1.datedebutsession.ToShortDateString()}";
 
            // Créer le code QR
            var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(texte, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            // Convertir le code QR en image
            var qrCodeImage = qrCode.GetGraphic(20);

            // Afficher le code QR dans une boîte de message
            MessageBox.Show("", "Code QR pour la session", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var pictureBox = new PictureBox();
            pictureBox.Image = qrCodeImage;
            pictureBox.Dock = DockStyle.Fill;
            var qrCodeForm = new Form();
            qrCodeForm.Size = new Size(qrCodeImage.Width + 20, qrCodeImage.Height + 60);
            qrCodeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            qrCodeForm.Text = "Code QR pour la session";
            qrCodeForm.Controls.Add(pictureBox);
            qrCodeForm.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();
            var foorm = (Data.SessionFormation)sessionFormationBindingSource.Current;
 
            ctx.Entry(foorm).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            ctx.Entry(foorm).State = System.Data.Entity.EntityState.Detached;
          
            MessageBox.Show("Session Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sessionFormationBindingSource.DataSource = ctx.SessionFormation.ToList();
            sessionFormationBindingSource.ResetBindings(false);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

            Data.FormationEntities ctx = new Data.FormationEntities();
            Data.SessionFormation rn = ctx.SessionFormation.Find(((Data.SessionFormation)sessionFormationBindingSource.Current).idsession);
            ctx.SessionFormation.Remove(rn);

            ctx.SaveChanges();
            MessageBox.Show("SessionFormation Delteed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sessionFormationBindingSource.DataSource = ctx.SessionFormation.ToList();
            sessionFormationBindingSource.ResetBindings(false);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sessionFormationBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void Session_Load(object sender, EventArgs e)
        {
            Data.FormationEntities ctx = new Data.FormationEntities();
            sessionFormationBindingSource.DataSource = ctx.SessionFormation.ToList();
            // Récupérer toutes les sessions de formation
            var sessions = ctx.SessionFormation.ToList();

            // Définir la colonne ComboBox pour le DataGridView
            var participantColumn = new DataGridViewComboBoxColumn();
            participantColumn.Name = "Participant";
            participantColumn.HeaderText = "Participant";
            participantColumn.ValueMember = "idparticipant";
            participantColumn.DisplayMember = "nom";

            // Ajouter la colonne ComboBox à la grille de données
            dataGridView1.Columns.Add(participantColumn);
            // Parcourir toutes les sessions de formation
            foreach (var session in sessions)
            {
                // Récupérer les PartSession correspondants à la session de formation actuelle
                var partSessions = session.PartSession.ToList();

                // Récupérer la liste de participants uniques pour cette session
                var uniqueParticipants = partSessions
                    .Select(ps => ps.Participant)
                    .Distinct()
                    .ToList();

                // Affecter la liste de participants uniques à la cellule de la colonne ComboBox correspondante à cette session
                var index = sessionFormationBindingSource.IndexOf(session);
                var participantCell = dataGridView1.Rows[index].Cells[participantColumn.Index] as DataGridViewComboBoxCell;
                participantCell.DataSource = uniqueParticipants;
                participantCell.ValueMember = "idparticipant";
                participantCell.DisplayMember = "nom";
            }

            // Récupérer tous les participants uniques pour toutes les sessions
            var allUniqueParticipants = sessions
                .SelectMany(s => s.PartSession)
                .Select(ps => ps.Participant)
                .Distinct()
                .ToList();

            // Affecter la liste de participants uniques à la propriété DataSource de la colonne participantColumn
            participantColumn.DataSource = allUniqueParticipants.Distinct().ToList();
            participantColumn.ValueMember = "idparticipant";
            participantColumn.DisplayMember = "nom";

            // Mettre à jour la source de données de la grille de données
            sessionFormationBindingSource.DataSource = sessions;

            sessionFormationBindingSource.ResetBindings(false);

            formateurBindingSource.DataSource = ctx.Formateur.ToList();
            formateurBindingSource.ResetBindings(false);
            participantBindingSource.DataSource = ctx.Participant.ToList();
            participantBindingSource.ResetBindings(false);
        }

        private void accordionControlElement3_Click_1(object sender, EventArgs e)
        {
            Formateur formateur = new Formateur();
            formateur.Show();
            this.Hide();
        }

        private void accordionControlElement2_Click_1(object sender, EventArgs e)
        {
            Participant_1 part = new Participant_1();
            part.Show();
            this.Hide();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            Reunion_1 part = new Reunion_1();
            part.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

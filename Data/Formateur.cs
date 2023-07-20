//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Formateur")]
    public partial class Formateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formateur()
        {
            this.SessionFormation = new HashSet<SessionFormation>();
            this.Reunionform = new HashSet<Reunionform>();
        }

        public Formateur(string nom, string prenom, string email, string specialite)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.specialite = specialite;
        }

        public Formateur(int idformateur, string nom, string prenom, string email, string specialite)
        {
            this.idformateur = idformateur;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.specialite = specialite;
        }

        [Key]
        public int idformateur { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string specialite { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionFormation> SessionFormation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reunionform> Reunionform { get; set; }
    }
}

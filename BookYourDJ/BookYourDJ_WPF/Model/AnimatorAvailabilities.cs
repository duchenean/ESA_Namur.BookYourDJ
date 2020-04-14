namespace BookYourDJ_WPF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnimatorAvailabilities
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimatorId { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime StartDatetime { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime EndDatetime { get; set; }

        public virtual Animators Animators { get; set; }
    }
}

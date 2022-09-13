namespace LiveCards.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Setting
    {
        [Key]
        public string KKey { get; set; }
        public string KVal { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string DefaultValue { get; set; }
    }
}

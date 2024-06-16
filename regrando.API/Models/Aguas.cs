using System;

namespace regrando.API.Models
{
    public partial class Aguas
    {
        public int IdAgua { get; set; }

        public TimeSpan? HrAgua { get; set; }

        public int? QtdAgua { get; set; }
    }
}
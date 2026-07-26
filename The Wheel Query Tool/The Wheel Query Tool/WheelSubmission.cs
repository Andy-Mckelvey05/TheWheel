using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Wheel_Query_Tool
{
    internal class WheelSubmission
    {
        public string MovieName { get; set; } = "";
        public int ReleaseYear { get; set; }
        public string LetterboxdLink { get; set; } = "";
        public List<DateTime> DatesWon { get; set; } = new();


        public string DatesWonDisplay()
        {
            return string.Join(", ",
                DatesWon.Select(d => d.ToString("dd MMM yyyy").Replace("Sept", "Sep")));
        }
    }
}

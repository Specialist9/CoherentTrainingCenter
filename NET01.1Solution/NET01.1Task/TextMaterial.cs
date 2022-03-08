using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public  class TextMaterial : Entity
    {
        string Text { get; set; }
        const int TextLength = 10000;
        public TextMaterial(string description, string text) : base(description)
        {
            Text = (String.IsNullOrEmpty(text) && text.Length <= TextLength)? throw new ArgumentNullException(nameof(text), "Text cannot be empty or be longer than 10000 chars") : text;
        }

        public override string ToString()
        {
            return Description.ToString();
        }
    }
}

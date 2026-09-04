using System;
using System.Collections.Generic;
using System.Text;

namespace BodegasAburtoWMS.Model
{
    public class ComboboxItem
    {
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }

        public override string ToString() => Text; // Obliga al ComboBox a mostrar el texto
    }
}

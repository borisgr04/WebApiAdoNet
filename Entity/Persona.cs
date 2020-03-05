using System;

namespace Entity
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

        public decimal Pulsacion
        {
            get
            {
                if (Sexo.Equals("F") || Sexo.Equals("f"))
                {
                    return (220 - Edad) / 10;
                }
                else
                {
                    return (210 - Edad) / 10;
                }


            }
        }
    }
}

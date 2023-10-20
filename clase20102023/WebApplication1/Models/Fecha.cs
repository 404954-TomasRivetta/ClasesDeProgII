namespace WebApplication1.Models
{
    public class Fecha
    {
        public int Dia { get; set; }

        public int Mes { get; set; }

        public int Anio { get; set; }
        public string DiaSemana { get; set; }

        public Fecha()
        {
            Dia= DateTime.Today.Day;
            Mes= DateTime.Today.Month;
            Anio= DateTime.Today.Year;
            DiaSemana = DateTime.Today.DayOfWeek.ToString();
        }

        //ESTO ES UN RECURSO
    }
}

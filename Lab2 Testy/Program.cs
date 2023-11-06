using System;

namespace WalidacjaPesel
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pesel = "92090663724"; // Przykładowy numer PESEL

            try
            {
                if (SprawdzPesel(pesel))
                {
                    Console.WriteLine("Numer PESEL jest poprawny.");
                }
                else
                {
                    Console.WriteLine("Numer PESEL jest niepoprawny.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }

        public static bool SprawdzPesel(string pesel)
        {
            if (string.IsNullOrEmpty(pesel))
            {
                throw new ArgumentNullException("pesel", "Wartość PESEL nie może być pusta ani null.");
            }

            if (pesel.Length != 11)
            {
                throw new Exception("Numer PESEL powinien składać się z 11 cyfr.");
            }

            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                if (!char.IsDigit(pesel[i]))
                {
                    throw new Exception("Numer PESEL powinien składać się tylko z cyfr.");
                }

                suma += int.Parse(pesel[i].ToString()) * wagi[i];
            }

            int ostatniaCyfra = int.Parse(pesel[10].ToString());
            int kontrolna = 10 - (suma % 10);

            if (kontrolna == 10)
            {
                kontrolna = 0;
            }

            return kontrolna == ostatniaCyfra;
        }
    }
}

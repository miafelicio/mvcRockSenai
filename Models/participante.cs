namespace exemplo.Models
{
    public class Participante : Usuario
    {
        public string ConfirmarChegada(){
            return "Confirmado em todos os dias";
        }

        public string ConfirmadoNaData(string nome){

            return $"confirmado no dia {nome}";
        }
    }
}
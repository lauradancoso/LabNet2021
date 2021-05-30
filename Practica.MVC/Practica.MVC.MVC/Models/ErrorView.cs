namespace Practica.MVC.MVC.Models
{
    public class ErrorView
    {
        public ErrorView(string Message)
        {
            this.Message = Message;
        }
        public string Message { get; set; }
    }
}
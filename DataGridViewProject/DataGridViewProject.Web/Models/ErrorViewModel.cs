namespace DataGridViewProject.Web.Models
{
    /// <summary>
    /// Модель для страницы ошибки
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Обозначает необходимо ли отображать идентификатор запроса на странице ошибки
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

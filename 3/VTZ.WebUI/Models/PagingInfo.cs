using System;

namespace VTZ.WebUI.Models
{
    public class PagingInfo
    {
        // Кол-во заданий
        public int TotalItems { get; set; }

        // Кол-во заданий на одной странице
        public int ItemsPerPage { get; set; }

        // Номер текущей страницы
        public int CurrentPage { get; set; }

        // Общее кол-во страниц
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}
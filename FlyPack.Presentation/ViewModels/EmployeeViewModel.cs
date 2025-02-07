﻿namespace FlyPack.Presentation.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string PersonType { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
    }
}

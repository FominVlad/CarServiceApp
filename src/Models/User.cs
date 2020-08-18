namespace CarServiceApp.Models
{
    public class User
    {
        /// <summary>
        /// Car model unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User password (hash).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}

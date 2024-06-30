

namespace BussinessObject
{
    public class Account
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int Status { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}

namespace ECommerce.Config
{
    public static class APIEndPoints
    {
        public const string BaseUrl = "https://ecomm-intern-demo.onrender.com/api";

        public static class Auth
        {
            public const string Login = $"{BaseUrl}/login";
            public const string Register = $"{BaseUrl}/register";
            public const string Logout = $"{BaseUrl}/logout";
        }
    }
}

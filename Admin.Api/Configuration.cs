namespace Admin.Api;

public class Configuration
{
    public static string CorsPolicyDev = "WebAppDev";

    public static string AdminApiUrl = "https://localhost:8081";

    public static string AdminAppUrl = "https://localhost:8091";

    //  ------------  Docker Stagin  ------------------------

    public static string CorsPolicyPro = "WebAppProd";

    public static string AdminApiConteiner = "172.20.254.2";

    public static string AdminAppConteiner = "172.20.254.3";
}

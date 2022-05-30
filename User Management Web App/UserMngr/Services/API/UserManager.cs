using Basics;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace UserMngr.Services.API
{
    public class UserManager : IUserManager
    {
        private HttpClient client; 
        public UserManager(HttpClient _client)
        {
            client = _client;

        }
        public async Task<string> ValidateUserEmail(string id)
        {
            string resultfailed = string.Empty;
            try
            {

                var result = await client.GetAsync($"api/Usuario/API/Validate/User/" + id);

                if (result != null )
                { 
                    
                    var a = result.Content.ReadAsStringAsync();
                    var b = a.Result;
                    var c = b.ToString();
                    return c;
                   // var a = await result.Content.ReadAsStringAsync();
                   // var b = JsonConvert.DeserializeObject<string>(a);
                    //if (b != null)
                    //    return b;
                    //if (b == null)
                    //    return String.Empty;
                }
            }
            catch (Exception e)
            {

                resultfailed= e.ToString();
            }
            finally { client.Dispose();
            
            
                  
            }
            return resultfailed;
            
        }

     
        public async Task<string> ResetPW(string id,string PW)
        {
            string resultfailed = string.Empty;
            try
            {
                NPW cont = new NPW() { ID = id, Password = PW };
                var json = JsonConvert.SerializeObject(cont);
                var jcontent = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync($"/api/oddddrequest/gotakeahikebro",jcontent);

                if (result != null)
                {

                    var a = result.Content.ReadAsStringAsync();
                    var b = a.Result;
                    var c = b.ToString();
                    return c;
                    // var a = await result.Content.ReadAsStringAsync();
                    // var b = JsonConvert.DeserializeObject<string>(a);
                    //if (b != null)
                    //    return b;
                    //if (b == null)
                    //    return String.Empty;
                }
            }
            catch (Exception e)
            {

                resultfailed = e.ToString();
            }
            finally
            {
                client.Dispose();



            }
            return resultfailed;

        }
        public async Task<string> VerifyLinkIsActive(string id)
        {
            string resultfailed = "Vaya a la app Martins BBQ, escriba su correo electronico y presione nuevamente olvide mi contraseña";
            try
            {


                
                var result = await client.GetAsync($"/api/verifylink/userid/" + id);

                if (result != null)
                {

                    var a = result.Content.ReadAsStringAsync();
                    var b = a.Result;
                    var c = b.ToString();
                    return c;
                    // var a = await result.Content.ReadAsStringAsync();
                    // var b = JsonConvert.DeserializeObject<string>(a);
                    //if (b != null)
                    //    return b;
                    //if (b == null)
                    //    return String.Empty;
                }
            }
            catch (Exception e)
            {

                resultfailed = e.ToString();
            }
            finally
            {
                client.Dispose();



            }
            return resultfailed;
        }
          
    }
}

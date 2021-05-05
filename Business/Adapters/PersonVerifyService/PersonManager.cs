using Entities.Concrete;
using KPSPublic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters.PersonVerifyService
{
    class PersonManager : IPersonService
    {
        public async Task<bool> VerifyCid(Customer customer)
        {
            return await Verify(customer);
        }

        private static async Task<bool> Verify(Customer customer)
        {
            var locale = new CultureInfo("tr-TR", false);
            var svc = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            {
                var cmd = await svc.TCKimlikNoDogrulaAsync(
                   Convert.ToInt64(customer.NationalityId),
                    customer.FirstName.ToUpper(locale),
                    customer.LastName.ToUpper(locale),
                    customer.DateOfBirth.Year);
                return cmd.Body.TCKimlikNoDogrulaResult;
            }
        }

    }
}
